
namespace Bai6._8
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
            this.flpBanBida = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTenBanChon = new System.Windows.Forms.Label();
            this.lblGioBatDau = new System.Windows.Forms.Label();
            this.btnMoBan = new System.Windows.Forms.Button();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.nmSoLuongDV = new System.Windows.Forms.NumericUpDown();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvChiTietDV = new System.Windows.Forms.DataGridView();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuongDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDV)).BeginInit();
            this.SuspendLayout();
            // 
            // flpBanBida
            // 
            this.flpBanBida.AutoScroll = true;
            this.flpBanBida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpBanBida.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpBanBida.Location = new System.Drawing.Point(436, 0);
            this.flpBanBida.Name = "flpBanBida";
            this.flpBanBida.Size = new System.Drawing.Size(364, 450);
            this.flpBanBida.TabIndex = 0;
            this.flpBanBida.Paint += new System.Windows.Forms.PaintEventHandler(this.flpBanBida_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnMoBan);
            this.groupBox1.Controls.Add(this.lblGioBatDau);
            this.groupBox1.Controls.Add(this.lblTenBanChon);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin Bàn chơi";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnThemDV);
            this.groupBox2.Controls.Add(this.nmSoLuongDV);
            this.groupBox2.Controls.Add(this.cboDichVu);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 99);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gọi Đồ uống / Thuê phụ kiện";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnThanhToan);
            this.groupBox3.Controls.Add(this.dgvChiTietDV);
            this.groupBox3.Location = new System.Drawing.Point(12, 223);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(418, 227);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách Dịch vụ đã gọi && Thanh toán";
            // 
            // lblTenBanChon
            // 
            this.lblTenBanChon.AutoSize = true;
            this.lblTenBanChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenBanChon.Location = new System.Drawing.Point(6, 16);
            this.lblTenBanChon.Name = "lblTenBanChon";
            this.lblTenBanChon.Size = new System.Drawing.Size(110, 16);
            this.lblTenBanChon.TabIndex = 0;
            this.lblTenBanChon.Text = "Chưa chọn bàn";
            this.lblTenBanChon.Click += new System.EventHandler(this.lblTenBanChon_Click);
            // 
            // lblGioBatDau
            // 
            this.lblGioBatDau.AutoSize = true;
            this.lblGioBatDau.Location = new System.Drawing.Point(6, 41);
            this.lblGioBatDau.Name = "lblGioBatDau";
            this.lblGioBatDau.Size = new System.Drawing.Size(84, 13);
            this.lblGioBatDau.TabIndex = 1;
            this.lblGioBatDau.Text = "Giờ bắt đầu: --:--";
            this.lblGioBatDau.Click += new System.EventHandler(this.lblGioBatDau_Click);
            // 
            // btnMoBan
            // 
            this.btnMoBan.BackColor = System.Drawing.Color.LightGreen;
            this.btnMoBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoBan.Location = new System.Drawing.Point(6, 57);
            this.btnMoBan.Name = "btnMoBan";
            this.btnMoBan.Size = new System.Drawing.Size(143, 37);
            this.btnMoBan.TabIndex = 2;
            this.btnMoBan.Text = "MỞ BÀN CHƠI";
            this.btnMoBan.UseVisualStyleBackColor = false;
            this.btnMoBan.Click += new System.EventHandler(this.btnMoBan_Click);
            // 
            // cboDichVu
            // 
            this.cboDichVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDichVu.FormattingEnabled = true;
            this.cboDichVu.Location = new System.Drawing.Point(59, 16);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(181, 21);
            this.cboDichVu.TabIndex = 0;
            this.cboDichVu.SelectedIndexChanged += new System.EventHandler(this.cboDichVu_SelectedIndexChanged);
            // 
            // nmSoLuongDV
            // 
            this.nmSoLuongDV.Location = new System.Drawing.Point(59, 42);
            this.nmSoLuongDV.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nmSoLuongDV.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSoLuongDV.Name = "nmSoLuongDV";
            this.nmSoLuongDV.Size = new System.Drawing.Size(181, 20);
            this.nmSoLuongDV.TabIndex = 1;
            this.nmSoLuongDV.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSoLuongDV.ValueChanged += new System.EventHandler(this.nmSoLuongDV_ValueChanged);
            // 
            // btnThemDV
            // 
            this.btnThemDV.Location = new System.Drawing.Point(6, 68);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(234, 23);
            this.btnThemDV.TabIndex = 2;
            this.btnThemDV.Text = "Thêm / Tăng Dịch Vụ";
            this.btnThemDV.UseVisualStyleBackColor = true;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dịch vụ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số lượng:";
            // 
            // dgvChiTietDV
            // 
            this.dgvChiTietDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietDV.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvChiTietDV.Location = new System.Drawing.Point(3, 16);
            this.dgvChiTietDV.Name = "dgvChiTietDV";
            this.dgvChiTietDV.ReadOnly = true;
            this.dgvChiTietDV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietDV.Size = new System.Drawing.Size(412, 166);
            this.dgvChiTietDV.TabIndex = 0;
            this.dgvChiTietDV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietDV_CellContentClick);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.BackColor = System.Drawing.Color.Orange;
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Location = new System.Drawing.Point(70, 188);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(264, 33);
            this.btnThanhToan.TabIndex = 1;
            this.btnThanhToan.Text = "THANH TOÁN && TÍNH GIỜ";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flpBanBida);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ BÀN BIDA & DỊCH VỤ GIẢI TRÍ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuongDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBanBida;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMoBan;
        private System.Windows.Forms.Label lblGioBatDau;
        private System.Windows.Forms.Label lblTenBanChon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.NumericUpDown nmSoLuongDV;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvChiTietDV;
        private System.Windows.Forms.Button btnThanhToan;
    }
}

