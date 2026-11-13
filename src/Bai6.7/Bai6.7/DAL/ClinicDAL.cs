using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Bai6._7.DTO;

namespace Bai6._7.DAL
{
    public class ClinicDAL : DatabaseAccess
    {
        // ================= 1. TIẾP NHẬN BỆNH NHÂN & HỒ SƠ KHÁM =================
        public DataTable TimBenhNhanTheoSDT(string sdt)
        {
            string query = "SELECT * FROM BenhNhan WHERE SoDienThoai = @SDT";
            MySqlParameter[] p = { new MySqlParameter("@SDT", sdt) };
            return ExecuteQuery(query, p);
        }

        public int TiepNhanVaTaoHoSo(BenhNhanDTO bn, string trieuChung, bool isNewPatient)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    int maBN = bn.MaBN;
                    if (isNewPatient)
                    {
                        string q1 = "INSERT INTO BenhNhan (HoTen, SoDienThoai, NamSinh) VALUES (@HoTen, @SDT, @NamSinh); SELECT LAST_INSERT_ID();";
                        MySqlCommand cmd1 = new MySqlCommand(q1, conn, trans);
                        cmd1.Parameters.AddWithValue("@HoTen", bn.HoTen);
                        cmd1.Parameters.AddWithValue("@SDT", bn.SoDienThoai);
                        cmd1.Parameters.AddWithValue("@NamSinh", bn.NamSinh);
                        maBN = Convert.ToInt32(cmd1.ExecuteScalar());
                    }

                    string q2 = "INSERT INTO HoSoKham (MaBN, NgayKham, TrieuChung, ChanDoan) VALUES (@MaBN, NOW(), @TrieuChung, 'Chờ khám'); SELECT LAST_INSERT_ID();";
                    MySqlCommand cmd2 = new MySqlCommand(q2, conn, trans);
                    cmd2.Parameters.AddWithValue("@MaBN", maBN);
                    cmd2.Parameters.AddWithValue("@TrieuChung", trieuChung);
                    int maHoSo = Convert.ToInt32(cmd2.ExecuteScalar());

                    trans.Commit();
                    return maHoSo;
                }
                catch
                {
                    trans.Rollback();
                    return 0;
                }
            }
        }

        public DataTable GetDanhSachHoSoKham()
        {
            string query = @"SELECT hs.MaHoSo, bn.HoTen, bn.SoDienThoai, bn.NamSinh, hs.NgayKham, hs.TrieuChung, hs.ChanDoan
                             FROM HoSoKham hs JOIN BenhNhan bn ON hs.MaBN = bn.MaBN
                             ORDER BY hs.MaHoSo DESC";
            return ExecuteQuery(query);
        }

        // ================= 2. QUẢN LÝ DANH MỤC THUỐC (CRUD) =================
        public DataTable GetDanhSachThuoc() => ExecuteQuery("SELECT * FROM Thuoc");

        public bool ThemThuocMoi(ThuocDTO t)
        {
            string query = "INSERT INTO Thuoc (TenThuoc, DonViTinh, DonGia, SoLuongTon) VALUES (@Ten, @DVT, @Gia, @Ton)";
            MySqlParameter[] p = {
                new MySqlParameter("@Ten", t.TenThuoc),
                new MySqlParameter("@DVT", t.DonViTinh),
                new MySqlParameter("@Gia", t.DonGia),
                new MySqlParameter("@Ton", t.SoLuongTon)
            };
            return ExecuteNonQuery(query, p) > 0;
        }

        public bool CapNhatThuoc(int maThuoc, decimal donGiaMoi, int soLuongNhapThem)
        {
            string query = "UPDATE Thuoc SET DonGia = @Gia, SoLuongTon = SoLuongTon + @Them WHERE MaThuoc = @Ma";
            MySqlParameter[] p = {
                new MySqlParameter("@Gia", donGiaMoi),
                new MySqlParameter("@Them", soLuongNhapThem),
                new MySqlParameter("@Ma", maThuoc)
            };
            return ExecuteNonQuery(query, p) > 0;
        }

        // ================= 3. KÊ ĐƠN THUỐC & XUẤT KHO (TRANSACTION) =================
        public bool LuuVaXuatDonThuocTransaction(int maHoSo, string chanDoan, decimal tienKham, List<ChiTietDonThuocDTO> listThuoc, out string errorMessage)
        {
            errorMessage = "";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // BƯỚC 1: Kiểm tra tồn kho của từng loại thuốc trong đơn
                    foreach (var item in listThuoc)
                    {
                        string qCheck = "SELECT SoLuongTon FROM Thuoc WHERE MaThuoc = @MaThuoc";
                        MySqlCommand cmdCheck = new MySqlCommand(qCheck, conn, trans);
                        cmdCheck.Parameters.AddWithValue("@MaThuoc", item.MaThuoc);

                        int tonHienTai = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (tonHienTai < item.SoLuong)
                        {
                            trans.Rollback();
                            errorMessage = $"Thuốc [{item.TenThuoc}] không đủ số lượng tồn kho! (Tồn: {tonHienTai}, Kê đơn: {item.SoLuong})";
                            return false;
                        }
                    }

                    // Cập nhật Chẩn đoán cho Hồ sơ khám
                    string qUpdateHS = "UPDATE HoSoKham SET ChanDoan = @ChanDoan WHERE MaHoSo = @MaHoSo";
                    MySqlCommand cmdHS = new MySqlCommand(qUpdateHS, conn, trans);
                    cmdHS.Parameters.AddWithValue("@ChanDoan", chanDoan);
                    cmdHS.Parameters.AddWithValue("@MaHoSo", maHoSo);
                    cmdHS.ExecuteNonQuery();

                    // Tính tổng tiền đơn thuốc = TienKham + Tổng tiền thuốc
                    decimal tongTienThuoc = 0;
                    foreach (var item in listThuoc) tongTienThuoc += item.ThanhTien;
                    decimal tongTien = tienKham + tongTienThuoc;

                    // BƯỚC 2: Tạo bản ghi DonThuoc
                    string q1 = "INSERT INTO DonThuoc (MaHoSo, TienKham, TongTien, TrangThai) VALUES (@MaHoSo, @TienKham, @TongTien, 'Chờ lấy thuốc'); SELECT LAST_INSERT_ID();";
                    MySqlCommand cmd1 = new MySqlCommand(q1, conn, trans);
                    cmd1.Parameters.AddWithValue("@MaHoSo", maHoSo);
                    cmd1.Parameters.AddWithValue("@TienKham", tienKham);
                    cmd1.Parameters.AddWithValue("@TongTien", tongTien);
                    int maDon = Convert.ToInt32(cmd1.ExecuteScalar());

                    // BƯỚC 3: Tạo các bản ghi ChiTietDonThuoc & Trừ SoLuongTon
                    foreach (var item in listThuoc)
                    {
                        string q2 = "INSERT INTO ChiTietDonThuoc (MaDon, MaThuoc, SoLuong, LieuDung) VALUES (@MaDon, @MaThuoc, @SoLuong, @LieuDung)";
                        MySqlCommand cmd2 = new MySqlCommand(q2, conn, trans);
                        cmd2.Parameters.AddWithValue("@MaDon", maDon);
                        cmd2.Parameters.AddWithValue("@MaThuoc", item.MaThuoc);
                        cmd2.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                        cmd2.Parameters.AddWithValue("@LieuDung", item.LieuDung);
                        cmd2.ExecuteNonQuery();

                        string q3 = "UPDATE Thuoc SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaThuoc = @MaThuoc";
                        MySqlCommand cmd3 = new MySqlCommand(q3, conn, trans);
                        cmd3.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                        cmd3.Parameters.AddWithValue("@MaThuoc", item.MaThuoc);
                        cmd3.ExecuteNonQuery();
                    }

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

        // ================= 4. THANH TOÁN & IN HÓA ĐƠN =================
        public DataTable GetDanhSachDonThuoc()
        {
            string query = @"SELECT dt.MaDon, dt.MaHoSo, bn.HoTen AS BenhNhan, bn.SoDienThoai, hs.ChanDoan, dt.TienKham, dt.TongTien, dt.TrangThai
                             FROM DonThuoc dt
                             JOIN HoSoKham hs ON dt.MaHoSo = hs.MaHoSo
                             JOIN BenhNhan bn ON hs.MaBN = bn.MaBN
                             ORDER BY dt.MaDon DESC";
            return ExecuteQuery(query);
        }

        public bool ThanhToanDonThuoc(int maDon)
        {
            string query = "UPDATE DonThuoc SET TrangThai = 'Đã thanh toán' WHERE MaDon = @MaDon";
            MySqlParameter[] p = { new MySqlParameter("@MaDon", maDon) };
            return ExecuteNonQuery(query, p) > 0;
        }
    }
}