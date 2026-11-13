using System.Collections.Generic;
using System.Data;
using Bai6._7.DAL;
using Bai6._7.DTO;

namespace Bai6._7.BUS
{
    public class ClinicBUS
    {
        private ClinicDAL dal = new ClinicDAL();

        public DataTable TimBenhNhanTheoSDT(string sdt) => dal.TimBenhNhanTheoSDT(sdt);
        public int TiepNhanVaTaoHoSo(BenhNhanDTO bn, string trieuChung, bool isNewPatient) => dal.TiepNhanVaTaoHoSo(bn, trieuChung, isNewPatient);
        public DataTable GetDanhSachHoSoKham() => dal.GetDanhSachHoSoKham();
        public DataTable GetDanhSachThuoc() => dal.GetDanhSachThuoc();
        public bool ThemThuocMoi(ThuocDTO t) => dal.ThemThuocMoi(t);
        public bool CapNhatThuoc(int maThuoc, decimal donGiaMoi, int soLuongNhapThem) => dal.CapNhatThuoc(maThuoc, donGiaMoi, soLuongNhapThem);
        public bool LuuVaXuatDonThuoc(int maHoSo, string chanDoan, decimal tienKham, List<ChiTietDonThuocDTO> listThuoc, out string errorMessage)
        {
            return dal.LuuVaXuatDonThuocTransaction(maHoSo, chanDoan, tienKham, listThuoc, out errorMessage);
        }
        public DataTable GetDanhSachDonThuoc() => dal.GetDanhSachDonThuoc();
        public bool ThanhToanDonThuoc(int maDon) => dal.ThanhToanDonThuoc(maDon);
    }
}