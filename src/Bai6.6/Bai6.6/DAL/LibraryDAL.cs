using System;
using System.Data;
using MySql.Data.MySqlClient;
using Bai6._6.DTO;

namespace Bai6._6.DAL
{
    public class LibraryDAL : DatabaseAccess
    {
        // ================= 1. QUẢN LÝ ĐẦU SÁCH & ĐỘC GIẢ (CRUD) =================
        public DataTable GetListDocGia() => ExecuteQuery("SELECT * FROM DocGia");
        public DataTable GetListDauSach() => ExecuteQuery("SELECT * FROM DauSach");

        public bool InsertDauSach(DauSachDTO sach)
        {
            string query = "INSERT INTO DauSach (TenSach, TheLoai, SoLuongCon) VALUES (@TenSach, @TheLoai, @SoLuongCon)";
            MySqlParameter[] p = {
                new MySqlParameter("@TenSach", sach.TenSach),
                new MySqlParameter("@TheLoai", sach.TheLoai),
                new MySqlParameter("@SoLuongCon", sach.SoLuongCon)
            };
            return ExecuteNonQuery(query, p) > 0;
        }

        public bool InsertDocGia(DocGiaDTO dg)
        {
            string query = "INSERT INTO DocGia (HoTen, Email, NgayHetHanThe) VALUES (@HoTen, @Email, @HanThe)";
            MySqlParameter[] p = {
                new MySqlParameter("@HoTen", dg.HoTen),
                new MySqlParameter("@Email", dg.Email),
                new MySqlParameter("@HanThe", dg.NgayHetHanThe)
            };
            return ExecuteNonQuery(query, p) > 0;
        }

        // ================= 2. LỌC PHIẾU MƯỢN THEO ĐỘC GIẢ & TRẠNG THÁI =================
        public DataTable GetPhieuMuonByFilter(int maDocGia, string trangThai)
        {
            string query = @"SELECT pm.MaPhieu, dg.HoTen AS DocGia, ds.TenSach, ct.SoLuong, pm.NgayMuon, pm.HanTra, pm.TrangThai
                             FROM PhieuMuon pm
                             JOIN DocGia dg ON pm.MaDocGia = dg.MaDocGia
                             JOIN ChiTietMuon ct ON pm.MaPhieu = ct.MaPhieu
                             JOIN DauSach ds ON ct.MaSach = ds.MaSach
                             WHERE (@MaDocGia = 0 OR pm.MaDocGia = @MaDocGia)
                               AND (@TrangThai = 'Tất cả' OR pm.TrangThai = @TrangThai)
                             ORDER BY pm.MaPhieu DESC";

            MySqlParameter[] p = {
                new MySqlParameter("@MaDocGia", maDocGia),
                new MySqlParameter("@TrangThai", trangThai)
            };
            return ExecuteQuery(query, p);
        }

        // ================= 3. LẬP PHIẾU MƯỢN MỚI (KIỂM TRA HẠN THẺ & TỒN KHO) =================
        public bool LapPhieuMuon(int maDocGia, int maSach, int soLuong, DateTime hanTra, out string errorMessage)
        {
            errorMessage = "";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Kiểm tra hạn thẻ độc giả (NgayHetHanThe >= NOW())
                    string qCheckThe = "SELECT NgayHetHanThe FROM DocGia WHERE MaDocGia = @MaDG";
                    MySqlCommand cmdThe = new MySqlCommand(qCheckThe, conn, trans);
                    cmdThe.Parameters.AddWithValue("@MaDG", maDocGia);
                    DateTime hanThe = Convert.ToDateTime(cmdThe.ExecuteScalar());

                    if (hanThe.Date < DateTime.Now.Date)
                    {
                        trans.Rollback();
                        errorMessage = $"Thẻ thư viện của độc giả đã hết hạn từ ngày {hanThe:dd/MM/yyyy}! Không thể mượn sách.";
                        return false;
                    }

                    // Kiểm tra số lượng sách còn lại
                    string qCheckSach = "SELECT SoLuongCon, TenSach FROM DauSach WHERE MaSach = @MaSach";
                    MySqlCommand cmdSach = new MySqlCommand(qCheckSach, conn, trans);
                    cmdSach.Parameters.AddWithValue("@MaSach", maSach);
                    int soLuongCon = 0;
                    string tenSach = "";
                    using (MySqlDataReader reader = cmdSach.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            soLuongCon = Convert.ToInt32(reader["SoLuongCon"]);
                            tenSach = reader["TenSach"].ToString();
                        }
                    }

                    if (soLuongCon < soLuong)
                    {
                        trans.Rollback();
                        errorMessage = $"Đầu sách [{tenSach}] không đủ số lượng cho mượn! (Còn lại: {soLuongCon})";
                        return false;
                    }

                    // Tạo Phiếu mượn
                    string q1 = "INSERT INTO PhieuMuon (MaDocGia, NgayMuon, HanTra, TrangThai) VALUES (@MaDG, NOW(), @HanTra, 'Đang mượn'); SELECT LAST_INSERT_ID();";
                    MySqlCommand cmd1 = new MySqlCommand(q1, conn, trans);
                    cmd1.Parameters.AddWithValue("@MaDG", maDocGia);
                    cmd1.Parameters.AddWithValue("@HanTra", hanTra);
                    int maPhieu = Convert.ToInt32(cmd1.ExecuteScalar());

                    // Tạo Chi tiết mượn
                    string q2 = "INSERT INTO ChiTietMuon (MaPhieu, MaSach, SoLuong) VALUES (@MaPhieu, @MaSach, @SoLuong)";
                    MySqlCommand cmd2 = new MySqlCommand(q2, conn, trans);
                    cmd2.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmd2.Parameters.AddWithValue("@MaSach", maSach);
                    cmd2.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd2.ExecuteNonQuery();

                    // Trừ số lượng sách còn
                    string q3 = "UPDATE DauSach SET SoLuongCon = SoLuongCon - @SoLuong WHERE MaSach = @MaSach";
                    MySqlCommand cmd3 = new MySqlCommand(q3, conn, trans);
                    cmd3.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd3.Parameters.AddWithValue("@MaSach", maSach);
                    cmd3.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    errorMessage = ex.Message;
                    return false;
                }
            }
        }

        // ================= 4. TRẢ SÁCH & CỘNG LẠI SỐ LƯỢNG SÁCH CÒN =================
        public bool TraSach(int maPhieu)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Cập nhật trạng thái Phiếu mượn sang 'Đã trả' bằng Parameterized SQL UPDATE
                    string q1 = "UPDATE PhieuMuon SET TrangThai = 'Đã trả' WHERE MaPhieu = @MaPhieu";
                    MySqlCommand cmd1 = new MySqlCommand(q1, conn, trans);
                    cmd1.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmd1.ExecuteNonQuery();

                    // Cộng lại SoLuongCon cho bảng DauSach
                    string q2 = @"UPDATE DauSach ds
                                  JOIN ChiTietMuon ct ON ds.MaSach = ct.MaSach
                                  SET ds.SoLuongCon = ds.SoLuongCon + ct.SoLuong
                                  WHERE ct.MaPhieu = @MaPhieu";
                    MySqlCommand cmd2 = new MySqlCommand(q2, conn, trans);
                    cmd2.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmd2.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        // ================= 5. CẢNH BÁO SÁCH QUÁ HẠN BẰNG DATA READER =================
        public DataTable GetOverdueBooks()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaPhieu", typeof(int));
            dt.Columns.Add("DocGia", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("TenSach", typeof(string));
            dt.Columns.Add("HanTra", typeof(DateTime));
            dt.Columns.Add("TrangThai", typeof(string));

            string query = @"SELECT pm.MaPhieu, dg.HoTen, dg.Email, ds.TenSach, pm.HanTra, pm.TrangThai
                             FROM PhieuMuon pm
                             JOIN DocGia dg ON pm.MaDocGia = dg.MaDocGia
                             JOIN ChiTietMuon ct ON pm.MaPhieu = ct.MaPhieu
                             JOIN DauSach ds ON ct.MaSach = ds.MaSach
                             WHERE pm.HanTra < NOW() AND pm.TrangThai != 'Đã trả'";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dt.Rows.Add(
                            reader["MaPhieu"],
                            reader["HoTen"],
                            reader["Email"],
                            reader["TenSach"],
                            reader["HanTra"],
                            reader["TrangThai"]
                        );
                    }
                }
            }
            return dt;
        }

        // ================= 6. THỐNG KÊ LƯỢT MƯỢN THEO THỂ LOẠI (GROUP BY) =================
        public DataTable GetBorrowStatByCategory()
        {
            string query = @"SELECT ds.TheLoai, 
                                    COUNT(DISTINCT ct.MaPhieu) AS SoLuotMuon,
                                    IFNULL(SUM(ct.SoLuong), 0) AS TongSoCuonDaMuon
                             FROM DauSach ds
                             LEFT JOIN ChiTietMuon ct ON ds.MaSach = ct.MaSach
                             GROUP BY ds.TheLoai";
            return ExecuteQuery(query);
        }
    }
}