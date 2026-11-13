using System.Data;
using Bai6._8.DAL;

namespace Bai6._8.BUS
{
    public class BilliardsBUS
    {
        private BilliardsDAL dal = new BilliardsDAL();

        public DataTable GetListBanBida() => dal.GetListBanBida();
        public DataTable GetListMenuDichVu() => dal.GetListMenuDichVu();
        public DataTable GetHoaDonChuaThanhToan(int maBan) => dal.GetHoaDonChuaThanhToan(maBan);
        public bool MoBanBida(int maBan) => dal.MoBanBida(maBan);
        public DataTable GetChiTietHoaDon(int maHD) => dal.GetChiTietHoaDon(maHD);
        public bool ThemHoacTangDichVu(int maHD, int maDV, int soLuong, decimal donGia) => dal.ThemHoacTangDichVu(maHD, maDV, soLuong, donGia);
        public bool ThanhToanHoaDon(int maHD, int maBan, out double soGioChoi, out decimal tienGio, out decimal tienDV, out string errorMessage)
        {
            return dal.ThanhToanHoaDon(maHD, maBan, out soGioChoi, out tienGio, out tienDV, out errorMessage);
        }
    }
}