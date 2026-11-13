
namespace Bai6._6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboFilterDocGia = new System.Windows.Forms.ComboBox();
            this.cboFilterTrangThai = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPhieuMuon = new System.Windows.Forms.DataGridView();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboDocGiaMuon = new System.Windows.Forms.ComboBox();
            this.cboSachMuon = new System.Windows.Forms.ComboBox();
            this.nmSoLuongMuon = new System.Windows.Forms.NumericUpDown();
            this.dtpHanTra = new System.Windows.Forms.DateTimePicker();
            this.btnLapPhieuMuon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboTheLoai = new System.Windows.Forms.ComboBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.nmSoLuongSach = new System.Windows.Forms.NumericUpDown();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.dgvDauSach = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtHoTenDG = new System.Windows.Forms.TextBox();
            this.txtEmailDG = new System.Windows.Forms.TextBox();
            this.dtpHanThe = new System.Windows.Forms.DateTimePicker();
            this.btnThemDocGia = new System.Windows.Forms.Button();
            this.dgvDocGia = new System.Windows.Forms.DataGridView();
            this.btnCanhBaoQuaHan = new System.Windows.Forms.Button();
            this.btnThongKeTheLoai = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuongMuon)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuongSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDauSach)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mượn & Trả Sách";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quản lý Đầu sách & Độc giả";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvReport);
            this.tabPage3.Controls.Add(this.btnThongKeTheLoai);
            this.tabPage3.Controls.Add(this.btnCanhBaoQuaHan);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(792, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cảnh báo Quá hạn & Thống kê";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.cboFilterTrangThai);
            this.groupBox1.Controls.Add(this.cboFilterDocGia);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc danh sách phiếu mượn";
            // 
            // cboFilterDocGia
            // 
            this.cboFilterDocGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterDocGia.FormattingEnabled = true;
            this.cboFilterDocGia.Location = new System.Drawing.Point(70, 19);
            this.cboFilterDocGia.Name = "cboFilterDocGia";
            this.cboFilterDocGia.Size = new System.Drawing.Size(176, 21);
            this.cboFilterDocGia.TabIndex = 0;
            this.cboFilterDocGia.SelectedIndexChanged += new System.EventHandler(this.cboFilterDocGia_SelectedIndexChanged);
            // 
            // cboFilterTrangThai
            // 
            this.cboFilterTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterTrangThai.FormattingEnabled = true;
            this.cboFilterTrangThai.Location = new System.Drawing.Point(70, 46);
            this.cboFilterTrangThai.Name = "cboFilterTrangThai";
            this.cboFilterTrangThai.Size = new System.Drawing.Size(176, 21);
            this.cboFilterTrangThai.TabIndex = 1;
            this.cboFilterTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboFilterTrangThai_SelectedIndexChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(252, 19);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(71, 48);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Lọc phiếu mượn";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Độc giả:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Trạng thái:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTraSach);
            this.groupBox2.Controls.Add(this.dgvPhieuMuon);
            this.groupBox2.Location = new System.Drawing.Point(3, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(789, 227);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách Phiếu mượn && Trả sách";
            // 
            // dgvPhieuMuon
            // 
            this.dgvPhieuMuon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuMuon.Location = new System.Drawing.Point(0, 19);
            this.dgvPhieuMuon.Name = "dgvPhieuMuon";
            this.dgvPhieuMuon.ReadOnly = true;
            this.dgvPhieuMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuMuon.Size = new System.Drawing.Size(789, 150);
            this.dgvPhieuMuon.TabIndex = 0;
            this.dgvPhieuMuon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuMuon_CellContentClick);
            // 
            // btnTraSach
            // 
            this.btnTraSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTraSach.BackColor = System.Drawing.Color.LightGreen;
            this.btnTraSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraSach.Location = new System.Drawing.Point(268, 175);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(236, 33);
            this.btnTraSach.TabIndex = 1;
            this.btnTraSach.Text = "Trả Sách Đã Chọn";
            this.btnTraSach.UseVisualStyleBackColor = false;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnLapPhieuMuon);
            this.groupBox3.Controls.Add(this.dtpHanTra);
            this.groupBox3.Controls.Add(this.nmSoLuongMuon);
            this.groupBox3.Controls.Add(this.cboSachMuon);
            this.groupBox3.Controls.Add(this.cboDocGiaMuon);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 321);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(786, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lập Phiếu Mượn Sách Mới";
            // 
            // cboDocGiaMuon
            // 
            this.cboDocGiaMuon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocGiaMuon.FormattingEnabled = true;
            this.cboDocGiaMuon.Location = new System.Drawing.Point(88, 19);
            this.cboDocGiaMuon.Name = "cboDocGiaMuon";
            this.cboDocGiaMuon.Size = new System.Drawing.Size(121, 21);
            this.cboDocGiaMuon.TabIndex = 0;
            this.cboDocGiaMuon.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cboSachMuon
            // 
            this.cboSachMuon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSachMuon.FormattingEnabled = true;
            this.cboSachMuon.Location = new System.Drawing.Point(88, 50);
            this.cboSachMuon.Name = "cboSachMuon";
            this.cboSachMuon.Size = new System.Drawing.Size(121, 21);
            this.cboSachMuon.TabIndex = 1;
            this.cboSachMuon.SelectedIndexChanged += new System.EventHandler(this.cboSachMuon_SelectedIndexChanged);
            // 
            // nmSoLuongMuon
            // 
            this.nmSoLuongMuon.Location = new System.Drawing.Point(329, 19);
            this.nmSoLuongMuon.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSoLuongMuon.Name = "nmSoLuongMuon";
            this.nmSoLuongMuon.Size = new System.Drawing.Size(120, 20);
            this.nmSoLuongMuon.TabIndex = 2;
            this.nmSoLuongMuon.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSoLuongMuon.ValueChanged += new System.EventHandler(this.nmSoLuongMuon_ValueChanged);
            // 
            // dtpHanTra
            // 
            this.dtpHanTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHanTra.Location = new System.Drawing.Point(329, 51);
            this.dtpHanTra.Name = "dtpHanTra";
            this.dtpHanTra.Size = new System.Drawing.Size(120, 20);
            this.dtpHanTra.TabIndex = 3;
            this.dtpHanTra.ValueChanged += new System.EventHandler(this.dtpHanTra_ValueChanged);
            // 
            // btnLapPhieuMuon
            // 
            this.btnLapPhieuMuon.BackColor = System.Drawing.Color.LightBlue;
            this.btnLapPhieuMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLapPhieuMuon.Location = new System.Drawing.Point(473, 19);
            this.btnLapPhieuMuon.Name = "btnLapPhieuMuon";
            this.btnLapPhieuMuon.Size = new System.Drawing.Size(174, 52);
            this.btnLapPhieuMuon.TabIndex = 4;
            this.btnLapPhieuMuon.Text = "Lập Phiếu Mượn";
            this.btnLapPhieuMuon.UseVisualStyleBackColor = false;
            this.btnLapPhieuMuon.Click += new System.EventHandler(this.btnLapPhieuMuon_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Độc giả mượn:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sách mượn:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Số lượng mượn: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(239, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Hạn trả:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvDauSach);
            this.groupBox4.Controls.Add(this.btnThemSach);
            this.groupBox4.Controls.Add(this.nmSoLuongSach);
            this.groupBox4.Controls.Add(this.txtTenSach);
            this.groupBox4.Controls.Add(this.cboTheLoai);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(368, 418);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Quản lý Đầu sách";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tên sách:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Thể loại:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Số lượng:";
            // 
            // cboTheLoai
            // 
            this.cboTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTheLoai.FormattingEnabled = true;
            this.cboTheLoai.Location = new System.Drawing.Point(67, 45);
            this.cboTheLoai.Name = "cboTheLoai";
            this.cboTheLoai.Size = new System.Drawing.Size(138, 21);
            this.cboTheLoai.TabIndex = 3;
            this.cboTheLoai.SelectedIndexChanged += new System.EventHandler(this.cboTheLoai_SelectedIndexChanged);
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(67, 19);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(138, 20);
            this.txtTenSach.TabIndex = 4;
            this.txtTenSach.TextChanged += new System.EventHandler(this.txtTenSach_TextChanged);
            // 
            // nmSoLuongSach
            // 
            this.nmSoLuongSach.Location = new System.Drawing.Point(67, 72);
            this.nmSoLuongSach.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSoLuongSach.Name = "nmSoLuongSach";
            this.nmSoLuongSach.Size = new System.Drawing.Size(138, 20);
            this.nmSoLuongSach.TabIndex = 5;
            this.nmSoLuongSach.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmSoLuongSach.ValueChanged += new System.EventHandler(this.nmSoLuongSach_ValueChanged);
            // 
            // btnThemSach
            // 
            this.btnThemSach.Location = new System.Drawing.Point(12, 98);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(193, 23);
            this.btnThemSach.TabIndex = 6;
            this.btnThemSach.Text = "Thêm Đầu Sách";
            this.btnThemSach.UseVisualStyleBackColor = true;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // dgvDauSach
            // 
            this.dgvDauSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDauSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDauSach.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDauSach.Location = new System.Drawing.Point(3, 127);
            this.dgvDauSach.Name = "dgvDauSach";
            this.dgvDauSach.ReadOnly = true;
            this.dgvDauSach.Size = new System.Drawing.Size(362, 288);
            this.dgvDauSach.TabIndex = 7;
            this.dgvDauSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDauSach_CellContentClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvDocGia);
            this.groupBox5.Controls.Add(this.btnThemDocGia);
            this.groupBox5.Controls.Add(this.dtpHanThe);
            this.groupBox5.Controls.Add(this.txtEmailDG);
            this.groupBox5.Controls.Add(this.txtHoTenDG);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox5.Location = new System.Drawing.Point(377, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(412, 418);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Quản lý Độc giả";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Họ tên độc giả:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Email:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Ngày hết hạn:";
            // 
            // txtHoTenDG
            // 
            this.txtHoTenDG.Location = new System.Drawing.Point(106, 19);
            this.txtHoTenDG.Name = "txtHoTenDG";
            this.txtHoTenDG.Size = new System.Drawing.Size(140, 20);
            this.txtHoTenDG.TabIndex = 3;
            this.txtHoTenDG.TextChanged += new System.EventHandler(this.txtHoTenDG_TextChanged);
            // 
            // txtEmailDG
            // 
            this.txtEmailDG.Location = new System.Drawing.Point(106, 45);
            this.txtEmailDG.Name = "txtEmailDG";
            this.txtEmailDG.Size = new System.Drawing.Size(140, 20);
            this.txtEmailDG.TabIndex = 4;
            this.txtEmailDG.TextChanged += new System.EventHandler(this.txtEmailDG_TextChanged);
            // 
            // dtpHanThe
            // 
            this.dtpHanThe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHanThe.Location = new System.Drawing.Point(106, 71);
            this.dtpHanThe.Name = "dtpHanThe";
            this.dtpHanThe.Size = new System.Drawing.Size(140, 20);
            this.dtpHanThe.TabIndex = 5;
            this.dtpHanThe.ValueChanged += new System.EventHandler(this.dtpHanThe_ValueChanged);
            // 
            // btnThemDocGia
            // 
            this.btnThemDocGia.Location = new System.Drawing.Point(9, 98);
            this.btnThemDocGia.Name = "btnThemDocGia";
            this.btnThemDocGia.Size = new System.Drawing.Size(237, 23);
            this.btnThemDocGia.TabIndex = 6;
            this.btnThemDocGia.Text = "Thêm Độc Giả";
            this.btnThemDocGia.UseVisualStyleBackColor = true;
            this.btnThemDocGia.Click += new System.EventHandler(this.btnThemDocGia_Click);
            // 
            // dgvDocGia
            // 
            this.dgvDocGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocGia.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDocGia.Location = new System.Drawing.Point(3, 127);
            this.dgvDocGia.Name = "dgvDocGia";
            this.dgvDocGia.ReadOnly = true;
            this.dgvDocGia.Size = new System.Drawing.Size(406, 288);
            this.dgvDocGia.TabIndex = 7;
            this.dgvDocGia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocGia_CellContentClick);
            // 
            // btnCanhBaoQuaHan
            // 
            this.btnCanhBaoQuaHan.BackColor = System.Drawing.Color.Orange;
            this.btnCanhBaoQuaHan.Location = new System.Drawing.Point(8, 15);
            this.btnCanhBaoQuaHan.Name = "btnCanhBaoQuaHan";
            this.btnCanhBaoQuaHan.Size = new System.Drawing.Size(199, 23);
            this.btnCanhBaoQuaHan.TabIndex = 0;
            this.btnCanhBaoQuaHan.Text = "Cảnh báo Sách Quá Hạn (Overdue)";
            this.btnCanhBaoQuaHan.UseVisualStyleBackColor = false;
            this.btnCanhBaoQuaHan.Click += new System.EventHandler(this.btnCanhBaoQuaHan_Click);
            // 
            // btnThongKeTheLoai
            // 
            this.btnThongKeTheLoai.Location = new System.Drawing.Point(8, 44);
            this.btnThongKeTheLoai.Name = "btnThongKeTheLoai";
            this.btnThongKeTheLoai.Size = new System.Drawing.Size(199, 23);
            this.btnThongKeTheLoai.TabIndex = 1;
            this.btnThongKeTheLoai.Text = "Thống Kê Lượt Mượn Theo Thể Loại";
            this.btnThongKeTheLoai.UseVisualStyleBackColor = true;
            this.btnThongKeTheLoai.Click += new System.EventHandler(this.btnThongKeTheLoai_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvReport.Location = new System.Drawing.Point(0, 73);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.Size = new System.Drawing.Size(792, 351);
            this.dgvReport.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ MƯỢN TRẢ SÁCH THƯ VIỆN";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuongMuon)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuongSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDauSach)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvPhieuMuon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cboFilterTrangThai;
        private System.Windows.Forms.ComboBox cboFilterDocGia;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLapPhieuMuon;
        private System.Windows.Forms.DateTimePicker dtpHanTra;
        private System.Windows.Forms.NumericUpDown nmSoLuongMuon;
        private System.Windows.Forms.ComboBox cboSachMuon;
        private System.Windows.Forms.ComboBox cboDocGiaMuon;
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvDocGia;
        private System.Windows.Forms.Button btnThemDocGia;
        private System.Windows.Forms.DateTimePicker dtpHanThe;
        private System.Windows.Forms.TextBox txtEmailDG;
        private System.Windows.Forms.TextBox txtHoTenDG;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvDauSach;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.NumericUpDown nmSoLuongSach;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.ComboBox cboTheLoai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnThongKeTheLoai;
        private System.Windows.Forms.Button btnCanhBaoQuaHan;
    }
}

