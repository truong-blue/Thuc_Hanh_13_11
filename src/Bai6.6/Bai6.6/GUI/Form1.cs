using System;
using System.Data;
using System.Windows.Forms;
using Bai6._6.BUS;
using Bai6._6.DTO;

namespace Bai6._6
{
    public partial class Form1 : Form
    {
        private LibraryBUS bus = new LibraryBUS();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ MƯỢN TRẢ SÁCH THƯ VIỆN (LIBRARY MANAGEMENT SYSTEM)";

            InitData();
            LoadPhieuMuon();
        }

        private void InitData()
        {
            try
            {
                // 1. Nạp danh sách Độc giả & Sách
                DataTable dtDG = bus.GetListDocGia();
                dgvDocGia.DataSource = dtDG;

                cboDocGiaMuon.DataSource = dtDG.Copy();
                cboDocGiaMuon.DisplayMember = "HoTen";
                cboDocGiaMuon.ValueMember = "MaDocGia";

                DataTable dtFilterDG = dtDG.Copy();
                DataRow r = dtFilterDG.NewRow();
                r["MaDocGia"] = 0;
                r["HoTen"] = "-- Tất cả Độc giả --";
                dtFilterDG.Rows.InsertAt(r, 0);
                cboFilterDocGia.DataSource = dtFilterDG;
                cboFilterDocGia.DisplayMember = "HoTen";
                cboFilterDocGia.ValueMember = "MaDocGia";

                DataTable dtSach = bus.GetListDauSach();
                dgvDauSach.DataSource = dtSach;

                cboSachMuon.DataSource = dtSach.Copy();
                cboSachMuon.DisplayMember = "TenSach";
                cboSachMuon.ValueMember = "MaSach";

                // 2. Nạp ComboBox Trạng thái & Thể loại
                cboFilterTrangThai.Items.Clear();
                cboFilterTrangThai.Items.AddRange(new string[] { "Tất cả", "Đang mượn", "Đã trả", "Quá hạn" });
                cboFilterTrangThai.SelectedIndex = 0;

                cboTheLoai.Items.Clear();
                cboTheLoai.Items.AddRange(new string[] { "Công nghệ thông tin", "Kinh tế", "Văn học", "Ngoại ngữ" });
                cboTheLoai.SelectedIndex = 0;

                dtpHanTra.Value = DateTime.Now.AddDays(14);
                dtpHanThe.Value = DateTime.Now.AddYears(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL LibraryDB: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPhieuMuon()
        {
            int maDG = Convert.ToInt32(cboFilterDocGia.SelectedValue ?? 0);
            string trangThai = cboFilterTrangThai.SelectedItem?.ToString() ?? "Tất cả";
            dgvPhieuMuon.DataSource = bus.GetPhieuMuonByFilter(maDG, trangThai);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadPhieuMuon();
        }

        // ================= LẬP PHIẾU MƯỢN MỚI =================
        private void btnLapPhieuMuon_Click(object sender, EventArgs e)
        {
            if (cboDocGiaMuon.SelectedValue == null || cboSachMuon.SelectedValue == null) return;

            int maDG = Convert.ToInt32(cboDocGiaMuon.SelectedValue);
            int maSach = Convert.ToInt32(cboSachMuon.SelectedValue);
            int soLuong = (int)nmSoLuongMuon.Value;
            DateTime hanTra = dtpHanTra.Value;

            string error = "";
            if (bus.LapPhieuMuon(maDG, maSach, soLuong, hanTra, out error))
            {
                MessageBox.Show("Lập phiếu mượn sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InitData();
                LoadPhieuMuon();
            }
            else
            {
                MessageBox.Show("Không thể lập phiếu mượn!\nLý do: " + error, "Cảnh báo Nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ================= TRẢ SÁCH =================
        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.CurrentRow == null) return;
            int maPhieu = Convert.ToInt32(dgvPhieuMuon.CurrentRow.Cells["MaPhieu"].Value);
            string trangThai = dgvPhieuMuon.CurrentRow.Cells["TrangThai"].Value.ToString();

            if (trangThai == "Đã trả")
            {
                MessageBox.Show("Phiếu mượn này đã được trả trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bus.TraSach(maPhieu))
            {
                MessageBox.Show($"Trả sách cho phiếu #{maPhieu} thành công! Đã cộng lại tồn kho sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InitData();
                LoadPhieuMuon();
            }
        }

        // ================= TAB 2: THÊM ĐẦU SÁCH & ĐỘC GIẢ =================
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đầu sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DauSachDTO sach = new DauSachDTO
            {
                TenSach = txtTenSach.Text.Trim(),
                TheLoai = cboTheLoai.SelectedItem.ToString(),
                SoLuongCon = (int)nmSoLuongSach.Value
            };

            if (bus.InsertDauSach(sach))
            {
                MessageBox.Show("Thêm đầu sách mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSach.Clear();
                InitData();
            }
        }

        private void btnThemDocGia_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTenDG.Text) || string.IsNullOrWhiteSpace(txtEmailDG.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Email độc giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DocGiaDTO dg = new DocGiaDTO
            {
                HoTen = txtHoTenDG.Text.Trim(),
                Email = txtEmailDG.Text.Trim(),
                NgayHetHanThe = dtpHanThe.Value
            };

            if (bus.InsertDocGia(dg))
            {
                MessageBox.Show("Đăng ký thẻ độc giả mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTenDG.Clear();
                txtEmailDG.Clear();
                InitData();
            }
        }

        // ================= TAB 3: CẢNH BÁO QUÁ HẠN & THỐNG KÊ =================
        private void btnCanhBaoQuaHan_Click(object sender, EventArgs e)
        {

        }

        private void btnThongKeTheLoai_Click(object sender, EventArgs e)
        {
            dgvReport.DataSource = bus.GetBorrowStatByCategory();
        }

        // ==============================================================
        // GIỮ LẠI CÁC HÀM SỰ KIỆN RỖNG TRÁNH LỖI DESIGNER
        // ==============================================================
        private void label3_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void cboFilterDocGia_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboFilterTrangThai_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvPhieuMuon_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cboDocGiaMuon_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboSachMuon_SelectedIndexChanged(object sender, EventArgs e) { }
        private void nmSoLuongMuon_ValueChanged(object sender, EventArgs e) { }
        private void dtpHanTra_ValueChanged(object sender, EventArgs e) { }
        private void txtTenSach_TextChanged(object sender, EventArgs e) { }
        private void cboTheLoai_SelectedIndexChanged(object sender, EventArgs e) { }
        private void nmSoLuongSach_ValueChanged(object sender, EventArgs e) { }
        private void dgvDauSach_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtHoTenDG_TextChanged(object sender, EventArgs e) { }
        private void txtEmailDG_TextChanged(object sender, EventArgs e) { }
        private void dtpHanThe_ValueChanged(object sender, EventArgs e) { }
        private void dgvDocGia_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvReport_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}