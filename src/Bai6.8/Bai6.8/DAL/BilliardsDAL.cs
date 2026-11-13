using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Bai6._8.DAL
{
    public class BilliardsDAL : DatabaseAccess
    {
        // ================= 1. DANH SÁCH BÀN & MENU DỊCH VỤ =================
        public DataTable GetListBanBida() => ExecuteQuery("SELECT * FROM BanBida");
        public DataTable GetListMenuDichVu() => ExecuteQuery("SELECT * FROM MenuDichVu");

        public DataTable GetHoaDonChuaThanhToan(int maBan)
        {
            string query = "SELECT * FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = 0 ORDER BY MaHD DESC LIMIT 1";
            MySqlParameter[] p = { new MySqlParameter("@MaBan", maBan) };
            return ExecuteQuery(query, p);
        }

        // ================= 2. MỞ BÀN BIDA =================
        public bool MoBanBida(int maBan)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string q1 = "INSERT INTO HoaDon (MaBan, GioBatDau, TrangThai) VALUES (@MaBan, NOW(), 0)";
                    MySqlCommand cmd1 = new MySqlCommand(q1, conn, trans);
                    cmd1.Parameters.AddWithValue("@MaBan", maBan);
                    cmd1.ExecuteNonQuery();

                    string q2 = "UPDATE BanBida SET TrangThai = 'Đang chơi' WHERE MaBan = @MaBan";
                    MySqlCommand cmd2 = new MySqlCommand(q2, conn, trans);
                    cmd2.Parameters.AddWithValue("@MaBan", maBan);
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

        // ================= 3. GỌI DỊCH VỤ NGẮT KẾT NỐI (DATATABLE) =================
        public DataTable GetChiTietHoaDon(int maHD)
        {
            string query = @"SELECT ct.MaDV, dv.TenDV, ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien
                             FROM ChiTietHoaDon ct
                             JOIN MenuDichVu dv ON ct.MaDV = dv.MaDV
                             WHERE ct.MaHD = @MaHD";
            MySqlParameter[] p = { new MySqlParameter("@MaHD", maHD) };
            return ExecuteQuery(query, p);
        }

        public bool ThemHoacTangDichVu(int maHD, int maDV, int soLuong, decimal donGia)
        {
            string query = @"INSERT INTO ChiTietHoaDon (MaHD, MaDV, SoLuong, DonGia)
                             VALUES (@MaHD, @MaDV, @SoLuong, @DonGia)
                             ON DUPLICATE KEY UPDATE SoLuong = SoLuong + @SoLuong";
            MySqlParameter[] p = {
                new MySqlParameter("@MaHD", maHD),
                new MySqlParameter("@MaDV", maDV),
                new MySqlParameter("@SoLuong", soLuong),
                new MySqlParameter("@DonGia", donGia)
            };
            return ExecuteNonQuery(query, p) > 0;
        }

        // ================= 4. TÍNH TIỀN & THANH TOÁN (TRANSACTION) =================
        public bool ThanhToanHoaDon(int maHD, int maBan, out double soGioChoi, out decimal tienGio, out decimal tienDV, out string errorMessage)
        {
            soGioChoi = 0;
            tienGio = 0;
            tienDV = 0;
            errorMessage = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Lấy GioBatDau và GiaTheoGio
                    string qInfo = @"SELECT hd.GioBatDau, b.GiaTheoGio
                                     FROM HoaDon hd JOIN BanBida b ON hd.MaBan = b.MaBan
                                     WHERE hd.MaHD = @MaHD";
                    MySqlCommand cmdInfo = new MySqlCommand(qInfo, conn, trans);
                    cmdInfo.Parameters.AddWithValue("@MaHD", maHD);

                    DateTime gioBatDau = DateTime.Now;
                    decimal giaTheoGio = 0;
                    using (MySqlDataReader reader = cmdInfo.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            gioBatDau = Convert.ToDateTime(reader["GioBatDau"]);
                            giaTheoGio = Convert.ToDecimal(reader["GiaTheoGio"]);
                        }
                    }

                    // Tính số giờ chơi (làm tròn tối thiểu block 15 phút = 0.25 giờ)
                    DateTime gioKetThuc = DateTime.Now;
                    double tongPhut = (gioKetThuc - gioBatDau).TotalMinutes;
                    int soBlock15Phut = Math.Max(1, (int)Math.Ceiling(tongPhut / 15.0));
                    soGioChoi = soBlock15Phut * 0.25;
                    tienGio = (decimal)soGioChoi * giaTheoGio;

                    // 2. Kiểm tra & trừ TonKho cho từng dịch vụ (bỏ qua dịch vụ thuê gậy)
                    DataTable dtCT = new DataTable();
                    string qCT = @"SELECT ct.MaDV, ct.SoLuong, ct.DonGia, dv.TenDV, dv.TonKho
                                   FROM ChiTietHoaDon ct JOIN MenuDichVu dv ON ct.MaDV = dv.MaDV
                                   WHERE ct.MaHD = @MaHD";
                    MySqlCommand cmdCT = new MySqlCommand(qCT, conn, trans);
                    cmdCT.Parameters.AddWithValue("@MaHD", maHD);
                    new MySqlDataAdapter(cmdCT).Fill(dtCT);

                    foreach (DataRow row in dtCT.Rows)
                    {
                        int maDV = Convert.ToInt32(row["MaDV"]);
                        string tenDV = row["TenDV"].ToString();
                        int slMua = Convert.ToInt32(row["SoLuong"]);
                        decimal donGia = Convert.ToDecimal(row["DonGia"]);
                        int tonKho = Convert.ToInt32(row["TonKho"]);

                        tienDV += slMua * donGia;

                        // Bỏ qua trừ kho nếu là dịch vụ thuê gậy/phụ kiện
                        if (!tenDV.ToLower().Contains("thuê"))
                        {
                            if (tonKho < slMua)
                            {
                                trans.Rollback();
                                errorMessage = $"Mặt hàng [{tenDV}] không đủ tồn kho! (Tồn: {tonKho}, Đã gọi: {slMua})";
                                return false;
                            }

                            string qTruKho = "UPDATE MenuDichVu SET TonKho = TonKho - @SL WHERE MaDV = @MaDV";
                            MySqlCommand cmdTru = new MySqlCommand(qTruKho, conn, trans);
                            cmdTru.Parameters.AddWithValue("@SL", slMua);
                            cmdTru.Parameters.AddWithValue("@MaDV", maDV);
                            cmdTru.ExecuteNonQuery();
                        }
                    }

                    // 3. Cập nhật HoaDon: GioKetThuc, TienGioChoi, TienDichVu, TrangThai = 1
                    string qUpdateHD = @"UPDATE HoaDon
                                         SET GioKetThuc = @GioKT, TienGioChoi = @TienGio, TienDichVu = @TienDV, TrangThai = 1
                                         WHERE MaHD = @MaHD";
                    MySqlCommand cmdHD = new MySqlCommand(qUpdateHD, conn, trans);
                    cmdHD.Parameters.AddWithValue("@GioKT", gioKetThuc);
                    cmdHD.Parameters.AddWithValue("@TienGio", tienGio);
                    cmdHD.Parameters.AddWithValue("@TienDV", tienDV);
                    cmdHD.Parameters.AddWithValue("@MaHD", maHD);
                    cmdHD.ExecuteNonQuery();

                    // 4. Cập nhật BanBida về trạng thái 'Trống'
                    string qUpdateBan = "UPDATE BanBida SET TrangThai = 'Trống' WHERE MaBan = @MaBan";
                    MySqlCommand cmdBan = new MySqlCommand(qUpdateBan, conn, trans);
                    cmdBan.Parameters.AddWithValue("@MaBan", maBan);
                    cmdBan.ExecuteNonQuery();

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
    }
}