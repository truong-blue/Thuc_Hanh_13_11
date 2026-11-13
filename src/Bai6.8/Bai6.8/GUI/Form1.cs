using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bai6._8.BUS;

namespace Bai6._8
{
    public partial class Form1 : Form
    {
        private BilliardsBUS bus = new BilliardsBUS();
        private int currentMaBan = 0;
        private int currentMaHD = 0;
        private string currentTenBan = "";

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ BÀN BIDA & DỊCH VỤ GIẢI TRÍ (BILLIARDS CLUB MANAGEMENT SYSTEM)";

            LoadVisualTableGrid();
            LoadComboDichVu();
        }

        // ================= 1. SƠ ĐỒ BÀN BIDA TRỰC QUAN (VISUAL TABLE GRID) =================
        private void LoadVisualTableGrid()
        {
            flpBanBida.Controls.Clear();
            DataTable dtBan = bus.GetListBanBida();

            foreach (DataRow row in dtBan.Rows)
            {
                int maBan = Convert.ToInt32(row["MaBan"]);
                string tenBan = row["TenBan"].ToString();
                string loaiBan = row["LoaiBan"].ToString();
                decimal giaGio = Convert.ToDecimal(row["GiaTheoGio"]);
                string trangThai = row["TrangThai"].ToString();

                Button btn = new Button
                {
                    Width = 155,
                    Height = 105,
                    Text = $"{tenBan}\n({loaiBan})\n{giaGio:N0}đ/h\n[{trangThai}]",
                    Tag = maBan,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Margin = new Padding(8)
                };
                if (trangThai == "Đang chơi")
                {
                    btn.BackColor = Color.LightCoral;
                    btn.ForeColor = Color.DarkRed;
                }
                else
                {
                    btn.BackColor = Color.LightGreen;
                    btn.ForeColor = Color.DarkGreen;
                }

                btn.Click += BtnBanBida_Click;
                flpBanBida.Controls.Add(btn);
            }
        }

        private void BtnBanBida_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            currentMaBan = Convert.ToInt32(btn.Tag);
            DataTable dtBan = bus.GetListBanBida();
            DataRow[] rows = dtBan.Select($"MaBan = {currentMaBan}");

            if (rows.Length > 0)
            {
                currentTenBan = rows[0]["TenBan"].ToString();
                string trangThai = rows[0]["TrangThai"].ToString();
                lblTenBanChon.Text = $"{currentTenBan} ({trangThai})";

                if (trangThai == "Đang chơi")
                {
                    btnMoBan.Enabled = false;
                    btnThemDV.Enabled = true;
                    btnThanhToan.Enabled = true;

                    DataTable dtHD = bus.GetHoaDonChuaThanhToan(currentMaBan);
                    if (dtHD.Rows.Count > 0)
                    {
                        currentMaHD = Convert.ToInt32(dtHD.Rows[0]["MaHD"]);
                        DateTime gioBatDau = Convert.ToDateTime(dtHD.Rows[0]["GioBatDau"]);
                        lblGioBatDau.Text = $"Giờ bắt đầu: {gioBatDau:HH:mm dd/MM/yyyy}";
                        LoadChiTietDichVu();
                    }
                }
                else
                {
                    btnMoBan.Enabled = true;
                    btnThemDV.Enabled = false;
                    btnThanhToan.Enabled = false;
                    lblGioBatDau.Text = "Giờ bắt đầu: --:--";
                    dgvChiTietDV.DataSource = null;
                    currentMaHD = 0;
                }
            }
        }

        private void LoadComboDichVu()
        {
            DataTable dtDV = bus.GetListMenuDichVu();
            cboDichVu.DataSource = dtDV;
            cboDichVu.DisplayMember = "TenDV";
            cboDichVu.ValueMember = "MaDV";
        }

        private void LoadChiTietDichVu()
        {
            if (currentMaHD == 0) return;
            DataTable dtCT = bus.GetChiTietHoaDon(currentMaHD);
            dgvChiTietDV.DataSource = dtCT;
            if (dgvChiTietDV.Columns["DonGia"] != null) dgvChiTietDV.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            if (dgvChiTietDV.Columns["ThanhTien"] != null) dgvChiTietDV.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        // ================= 2. MỞ BÀN BIDA =================
        private void btnMoBan_Click(object sender, EventArgs e)
        {
            if (currentMaBan == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 bàn trống từ sơ đồ bên trái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bus.MoBanBida(currentMaBan))
            {
                MessageBox.Show($"Mở {currentTenBan} thành công! Bắt đầu tính giờ chơi.", "Mở bàn thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVisualTableGrid();
                BtnBanBida_Click(FindButtonByMaBan(currentMaBan), e);
            }
        }

        // ================= 3. GỌI ĐỒ UỐNG / THUÊ PHỤ KIỆN =================
        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if (currentMaHD == 0 || cboDichVu.SelectedValue == null) return;

            int maDV = Convert.ToInt32(cboDichVu.SelectedValue);
            DataRowView row = cboDichVu.SelectedItem as DataRowView;
            decimal donGia = Convert.ToDecimal(row["DonGia"]);
            int soLuong = (int)nmSoLuongDV.Value;

            if (bus.ThemHoacTangDichVu(currentMaHD, maDV, soLuong, donGia))
            {
                LoadChiTietDichVu();
            }
        }

        // ================= 4. TÍNH GIỜ & THANH TOÁN (TRANSACTION) =================
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (currentMaHD == 0) return;

            double soGio = 0;
            decimal tienGio = 0, tienDV = 0;
            string error = "";

            bool ok = bus.ThanhToanHoaDon(currentMaHD, currentMaBan, out soGio, out tienGio, out tienDV, out error);

            if (ok)
            {
                decimal tongCong = tienGio + tienDV;
                string msg = $"[HÓA ĐƠN THANH TOÁN - {currentTenBan}]\n" +
                             $"- Thời gian chơi (làm tròn block 15p): {soGio:0.##} giờ\n" +
                             $"- Tiền giờ chơi: {tienGio:N0} VNĐ\n" +
                             $"- Tiền dịch vụ & đồ uống: {tienDV:N0} VNĐ\n" +
                             $"----------------------------------------\n" +
                             $"TỔNG THANH TOÁN: {tongCong:N0} VNĐ\n\n" +
                             $"Thanh toán thành công! Bàn đã chuyển về trạng thái Trống.";

                MessageBox.Show(msg, "Thanh Toán Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                currentMaHD = 0;
                currentMaBan = 0;
                lblTenBanChon.Text = "Chưa chọn bàn";
                lblGioBatDau.Text = "Giờ bắt đầu: --:--";
                dgvChiTietDV.DataSource = null;

                LoadVisualTableGrid();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại (Rollback Transaction)!\nChi tiết: " + error, "Lỗi Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Button FindButtonByMaBan(int maBan)
        {
            foreach (Control c in flpBanBida.Controls)
            {
                if (c is Button btn && Convert.ToInt32(btn.Tag) == maBan) return btn;
            }
            return null;
        }
        // GIỮ LẠI CÁC HÀM SỰ KIỆN RỖNG TRÁNH LỖI DESIGNER
        private void lblTenBanChon_Click(object sender, EventArgs e) { }
        private void lblGioBatDau_Click(object sender, EventArgs e) { }
        private void cboDichVu_SelectedIndexChanged(object sender, EventArgs e) { }
        private void nmSoLuongDV_ValueChanged(object sender, EventArgs e) { }
        private void dgvChiTietDV_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void flpBanBida_Paint(object sender, PaintEventArgs e) { }
    }
}