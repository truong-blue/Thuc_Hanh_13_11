using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai6._7.DTO
{
    public class ChiTietDonThuocDTO
    {
        public int MaDon { get; set; }
        public int MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public string LieuDung { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;
    }
}
