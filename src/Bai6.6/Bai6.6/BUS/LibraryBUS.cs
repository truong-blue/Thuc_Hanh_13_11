using System;
using System.Data;
using Bai6._6.DAL;
using Bai6._6.DTO;

namespace Bai6._6.BUS
{
    public class LibraryBUS
    {
        private LibraryDAL dal = new LibraryDAL();

        public DataTable GetListDocGia() => dal.GetListDocGia();
        public DataTable GetListDauSach() => dal.GetListDauSach();
        public bool InsertDauSach(DauSachDTO sach) => dal.InsertDauSach(sach);
        public bool InsertDocGia(DocGiaDTO dg) => dal.InsertDocGia(dg);
        public DataTable GetPhieuMuonByFilter(int maDocGia, string trangThai) => dal.GetPhieuMuonByFilter(maDocGia, trangThai);
        public bool LapPhieuMuon(int maDocGia, int maSach, int soLuong, DateTime hanTra, out string errorMessage)
        {
            return dal.LapPhieuMuon(maDocGia, maSach, soLuong, hanTra, out errorMessage);
        }
        public bool TraSach(int maPhieu) => dal.TraSach(maPhieu);
        public DataTable GetOverdueBooks() => dal.GetOverdueBooks();
        public DataTable GetBorrowStatByCategory() => dal.GetBorrowStatByCategory();
    }
}