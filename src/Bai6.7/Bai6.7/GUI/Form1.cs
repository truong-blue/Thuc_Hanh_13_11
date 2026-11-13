using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Bai6._7.BUS;
using Bai6._7.DTO;

namespace Bai6._7
{
    public partial class Form1 : Form
    {
        private ClinicBUS bus = new ClinicBUS();
        private BindingList<ChiTietDonThuocDTO> gioThuoc = new BindingList<ChiTietDonThuocDTO>();
        private int currentMaBN = 0;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.btnLuuXuatDon.Click += btnLuuXuatDon_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ PHÒNG KHÁM & KÊ ĐƠN THUỐC (CLINIC & PHARMACY MANAGEMENT SYSTEM)";

            cboDonViTinh.Items.Clear();
            cboDonViTinh.Items.AddRange(new string[] { "Viên", "Vỉ", "Chai", "Hộp", "Tuýp" });
            cboDonViTinh.SelectedIndex = 0;

            dgvGioThuoc.DataSource = gioThuoc;
            LoadAllData();
        }

        private void LoadAllData()
        {
            try
            {
                DataTable dtHS = bus.GetDanhSachHoSoKham();
                dgvHoSoKham.DataSource = dtHS;
                DataTable dtCboHS = dtHS.Copy();
                dtCboHS.Columns.Add("HienThi", typeof(string), "'HS #' + MaHoSo + ' - ' + HoTen + ' (' + SoDienThoai + ')'");
                cboHoSoKham.DataSource = dtCboHS;
                cboHoSoKham.DisplayMember = "HienThi";
                cboHoSoKham.ValueMember = "MaHoSo";

                DataTable dtThuoc = bus.GetDanhSachThuoc();
                dgvThuoc.DataSource = dtThuoc;

                cboChonThuoc.DataSource = dtThuoc.Copy();
                cboChonThuoc.DisplayMember = "TenThuoc";
                cboChonThuoc.ValueMember = "MaThuoc";

                dgvDonThuoc.DataSource = bus.GetDanhSachDonThuoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL ClinicDB: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= TAB 1: TRA CỨU & TIẾP NHẬN BỆNH NHÂN =================
        private void btnTimSDT_Click(object sender, EventArgs e)
        {
            string sdt = txtTimSDT.Text.Trim();
            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại để tra cứu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = bus.TimBenhNhanTheoSDT(sdt);
            if (dt.Rows.Count > 0)
            {
                currentMaBN = Convert.ToInt32(dt.Rows[0]["MaBN"]);
                txtHoTenBN.Text = dt.Rows[0]["HoTen"].ToString();
                nmNamSinh.Value = Convert.ToInt32(dt.Rows[0]["NamSinh"]);
                txtHoTenBN.ReadOnly = true;
                MessageBox.Show("Đã tìm thấy thông tin bệnh nhân cũ trong hệ thống!", "Tra cứu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                currentMaBN = 0;
                txtHoTenBN.Clear();
                txtHoTenBN.ReadOnly = false;
                txtHoTenBN.Focus();
                MessageBox.Show("Số điện thoại mới! Vui lòng nhập Họ tên và Năm sinh để tạo hồ sơ mới.", "Bệnh nhân mới", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTiepNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimSDT.Text) || string.IsNullOrWhiteSpace(txtHoTenBN.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ SĐT và Họ tên bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BenhNhanDTO bn = new BenhNhanDTO
            {
                MaBN = currentMaBN,
                HoTen = txtHoTenBN.Text.Trim(),
                SoDienThoai = txtTimSDT.Text.Trim(),
                NamSinh = (int)nmNamSinh.Value
            };

            int maHoSo = bus.TiepNhanVaTaoHoSo(bn, txtTrieuChung.Text.Trim(), currentMaBN == 0);
            if (maHoSo > 0)
            {
                MessageBox.Show($"Tiếp nhận bệnh nhân thành công! Mã Hồ sơ khám mới: #{maHoSo}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTrieuChung.Clear();
                txtHoTenBN.ReadOnly = false;
                currentMaBN = 0;
                LoadAllData();
            }
            else
            {
                MessageBox.Show("Tiếp nhận thất bại (Kiểm tra trùng SĐT)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= TAB 1: QUẢN LÝ KHO THUỐC (CRUD) =================
        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenThuoc.Text)) return;

            ThuocDTO t = new ThuocDTO
            {
                TenThuoc = txtTenThuoc.Text.Trim(),
                DonViTinh = cboDonViTinh.SelectedItem.ToString(),
                DonGia = nmDonGiaThuoc.Value,
                SoLuongTon = (int)nmSoLuongNhap.Value
            };

            if (bus.ThemThuocMoi(t))
            {
                MessageBox.Show("Thêm thuốc mới vào kho dược thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenThuoc.Clear();
                LoadAllData();
            }
        }

        private void btnCapNhatThuoc_Click(object sender, EventArgs e)
        {
            if (dgvThuoc.CurrentRow == null) return;
            int maThuoc = Convert.ToInt32(dgvThuoc.CurrentRow.Cells["MaThuoc"].Value);
            string tenThuoc = dgvThuoc.CurrentRow.Cells["TenThuoc"].Value.ToString();

            if (bus.CapNhatThuoc(maThuoc, nmDonGiaThuoc.Value, (int)nmSoLuongNhap.Value))
            {
                MessageBox.Show($"Đã cập nhật giá và nhập thêm {(int)nmSoLuongNhap.Value} đơn vị cho thuốc [{tenThuoc}]!", "Cập nhật kho thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllData();
            }
        }

        // ================= TAB 2: KÊ ĐƠN THUỐC & XUẤT KHO (TRANSACTION) =================
        private void btnThemVaoDon_Click(object sender, EventArgs e)
        {
            if (cboChonThuoc.SelectedValue == null) return;

            int maThuoc = Convert.ToInt32(cboChonThuoc.SelectedValue);
            DataRowView row = cboChonThuoc.SelectedItem as DataRowView;
            string tenThuoc = row["TenThuoc"].ToString();
            string dvt = row["DonViTinh"].ToString();
            decimal donGia = Convert.ToDecimal(row["DonGia"]);
            int soLuong = (int)nmSoLuongKe.Value;
            string lieuDung = txtLieuDung.Text.Trim();

            foreach (var item in gioThuoc)
            {
                if (item.MaThuoc == maThuoc)
                {
                    item.SoLuong += soLuong;
                    dgvGioThuoc.Refresh();
                    CapNhatTongTien();
                    return;
                }
            }

            gioThuoc.Add(new ChiTietDonThuocDTO
            {
                MaThuoc = maThuoc,
                TenThuoc = tenThuoc,
                DonViTinh = dvt,
                SoLuong = soLuong,
                DonGia = donGia,
                LieuDung = lieuDung
            });
            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            decimal tongThuoc = 0;
            foreach (var item in gioThuoc) tongThuoc += item.ThanhTien;
            decimal tongCong = nmTienKham.Value + tongThuoc;
            lblTongTienDon.Text = $"Tổng viện phí (Khám + Thuốc): {tongCong:N0} VNĐ";
        }

        private void btnLuuXuatDon_Click(object sender, EventArgs e)
        {
            if (cboHoSoKham.SelectedValue == null || gioThuoc.Count == 0 || string.IsNullOrWhiteSpace(txtChanDoan.Text))
            {
                MessageBox.Show("Vui lòng chọn Hồ sơ khám, nhập Chẩn đoán và kê ít nhất 1 loại thuốc!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHoSo = Convert.ToInt32(cboHoSoKham.SelectedValue);
            string error = "";
            List<ChiTietDonThuocDTO> list = new List<ChiTietDonThuocDTO>(gioThuoc);

            if (bus.LuuVaXuatDonThuoc(maHoSo, txtChanDoan.Text.Trim(), nmTienKham.Value, list, out error))
            {
                MessageBox.Show("Lưu đơn thuốc & Xuất kho dược thành công (Commit Transaction)!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gioThuoc.Clear();
                txtChanDoan.Clear();
                CapNhatTongTien();
                LoadAllData();
            }
            else
            {
                MessageBox.Show("Lưu đơn thuốc thất bại (Rollback Transaction)!\nChi tiết: " + error, "Lỗi Transaction Kho Thuốc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= TAB 3: THANH TOÁN & IN HÓA ĐƠN =================
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvDonThuoc.CurrentRow == null) return;
            int maDon = Convert.ToInt32(dgvDonThuoc.CurrentRow.Cells["MaDon"].Value);
            string benhNhan = dgvDonThuoc.CurrentRow.Cells["BenhNhan"].Value.ToString();
            string chanDoan = dgvDonThuoc.CurrentRow.Cells["ChanDoan"].Value.ToString();
            decimal tienKham = Convert.ToDecimal(dgvDonThuoc.CurrentRow.Cells["TienKham"].Value);
            decimal tongTien = Convert.ToDecimal(dgvDonThuoc.CurrentRow.Cells["TongTien"].Value);
            string trangThai = dgvDonThuoc.CurrentRow.Cells["TrangThai"].Value.ToString();

            if (trangThai == "Đã thanh toán")
            {
                MessageBox.Show("Đơn thuốc này đã được thanh toán trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (bus.ThanhToanDonThuoc(maDon))
            {
                string hoaDon = $"[HÓA ĐƠN VIỆN PHÍ & ĐƠN THUỐC #{maDon}]\n" +
                                $"- Bệnh nhân: {benhNhan}\n" +
                                $"- Chẩn đoán: {chanDoan}\n" +
                                $"- Tiền khám: {tienKham:N0} VNĐ\n" +
                                $"- Tiền thuốc: {(tongTien - tienKham):N0} VNĐ\n" +
                                $"----------------------------------------\n" +
                                $"TỔNG THANH TOÁN: {tongTien:N0} VNĐ\n\n" +
                                $"Trạng thái: Đã thanh toán.";

                MessageBox.Show(hoaDon, "Thanh Toán & In Hóa Đơn Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllData();
            }
        }
        private void txtTimSDT_TextChanged(object sender, EventArgs e) { }
        private void txtHoTenBN_TextChanged(object sender, EventArgs e) { }
        private void nmNamSinh_ValueChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void dgvHoSoKham_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtTenThuoc_TextChanged(object sender, EventArgs e) { }
        private void cboDonViTinh_SelectedIndexChanged(object sender, EventArgs e) { }
        private void nmDonGiaThuoc_ValueChanged(object sender, EventArgs e) { }
        private void nmSoLuongNhap_ValueChanged(object sender, EventArgs e) { }
        private void dgvThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cboHoSoKham_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtChanDoan_TextChanged(object sender, EventArgs e) { }
        private void nmTienKham_ValueChanged(object sender, EventArgs e) { CapNhatTongTien(); }
        private void cboChonThuoc_SelectedIndexChanged(object sender, EventArgs e) { }
        private void nmSoLuongKe_ValueChanged(object sender, EventArgs e) { }
        private void txtLieuDung_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvDonThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}