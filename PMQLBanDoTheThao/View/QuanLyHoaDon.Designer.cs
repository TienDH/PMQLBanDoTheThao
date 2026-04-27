namespace PMQLBanDoTheThao.View
{
    partial class QuanLyHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.groupSanPham = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMauSac = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nmSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThem = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLamMoi2 = new System.Windows.Forms.Button();
            this.txtVoucher = new System.Windows.Forms.TextBox();
            this.txtMaVoucher = new System.Windows.Forms.Button();
            this.lblGiamGia = new System.Windows.Forms.Label();

            this.panelBottom = new System.Windows.Forms.Panel();
            this.groupThanhToan = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnXuatHoaDon = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();

            this.panelFill = new System.Windows.Forms.Panel();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();

            this.panelHeader = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnlammoi = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            this.groupSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.groupThanhToan.SuspendLayout();
            this.panelFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.SuspendLayout();

            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelTop.Controls.Add(this.groupSanPham);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(15);
            this.panelTop.Size = new System.Drawing.Size(961, 185); // Nới rộng panelTop
            this.panelTop.TabIndex = 0;
            // 
            // groupSanPham
            // 
            this.groupSanPham.BackColor = System.Drawing.Color.White;
            this.groupSanPham.Controls.Add(this.btnLamMoi2);
            this.groupSanPham.Controls.Add(this.label1);
            this.groupSanPham.Controls.Add(this.cboSanPham);
            this.groupSanPham.Controls.Add(this.label2);
            this.groupSanPham.Controls.Add(this.cboSize);
            this.groupSanPham.Controls.Add(this.label3);
            this.groupSanPham.Controls.Add(this.cboMauSac);
            this.groupSanPham.Controls.Add(this.label4);
            this.groupSanPham.Controls.Add(this.nmSoLuong);
            this.groupSanPham.Controls.Add(this.btnThem);
            this.groupSanPham.Controls.Add(this.button1);
            this.groupSanPham.Controls.Add(this.button2);
            // ĐÃ CHUYỂN VOUCHER VÀO ĐÂY
            this.groupSanPham.Controls.Add(this.txtVoucher);
            this.groupSanPham.Controls.Add(this.txtMaVoucher);
            this.groupSanPham.Controls.Add(this.lblGiamGia);

            this.groupSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSanPham.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupSanPham.Location = new System.Drawing.Point(15, 15);
            this.groupSanPham.Name = "groupSanPham";
            this.groupSanPham.Size = new System.Drawing.Size(931, 155); // Nới rộng GroupBox
            this.groupSanPham.TabIndex = 0;
            this.groupSanPham.TabStop = false;
            this.groupSanPham.Text = " Chọn Sản Phẩm & Khuyến Mãi ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(25, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sản phẩm:";
            // 
            // cboSanPham
            // 
            this.cboSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSanPham.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboSanPham.Location = new System.Drawing.Point(105, 37);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(350, 29);
            this.cboSanPham.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(25, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kích cỡ:";
            // 
            // cboSize
            // 
            this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSize.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboSize.Location = new System.Drawing.Point(105, 77);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(120, 29);
            this.cboSize.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(245, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Màu sắc:";
            // 
            // cboMauSac
            // 
            this.cboMauSac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMauSac.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboMauSac.Location = new System.Drawing.Point(315, 77);
            this.cboMauSac.Name = "cboMauSac";
            this.cboMauSac.Size = new System.Drawing.Size(140, 29);
            this.cboMauSac.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(480, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số lượng:";
            // 
            // nmSoLuong
            // 
            this.nmSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nmSoLuong.Location = new System.Drawing.Point(555, 38);
            this.nmSoLuong.Name = "nmSoLuong";
            this.nmSoLuong.Size = new System.Drawing.Size(70, 29);
            this.nmSoLuong.TabIndex = 7;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(650, 32);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 35);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "+ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(770, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 35);
            this.button1.TabIndex = 9;
            this.button1.Text = "Sửa dòng";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(650, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 35);
            this.button2.TabIndex = 10;
            this.button2.Text = "Xóa dòng";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLamMoi2
            // 
            this.btnLamMoi2.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnLamMoi2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi2.FlatAppearance.BorderSize = 0;
            this.btnLamMoi2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi2.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi2.Location = new System.Drawing.Point(770, 75);
            this.btnLamMoi2.Name = "btnLamMoi2";
            this.btnLamMoi2.Size = new System.Drawing.Size(110, 35);
            this.btnLamMoi2.TabIndex = 11;
            this.btnLamMoi2.Text = "Làm Mới";
            this.btnLamMoi2.UseVisualStyleBackColor = false;
            this.btnLamMoi2.Click += new System.EventHandler(this.btnlammoi_Click);
            // 
            // txtVoucher
            // 
            this.txtVoucher.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVoucher.ForeColor = System.Drawing.Color.Gray;
            this.txtVoucher.Location = new System.Drawing.Point(105, 116);
            this.txtVoucher.Name = "txtVoucher";
            this.txtVoucher.Size = new System.Drawing.Size(180, 30);
            this.txtVoucher.TabIndex = 12;
            
            // 
            // txtMaVoucher
            // 
            this.txtMaVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.txtMaVoucher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtMaVoucher.FlatAppearance.BorderSize = 0;
            this.txtMaVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtMaVoucher.ForeColor = System.Drawing.Color.White;
            this.txtMaVoucher.Location = new System.Drawing.Point(295, 115);
            this.txtMaVoucher.Name = "txtMaVoucher";
            this.txtMaVoucher.Size = new System.Drawing.Size(90, 32);
            this.txtMaVoucher.TabIndex = 13;
            this.txtMaVoucher.Text = "Áp mã";
            this.txtMaVoucher.UseVisualStyleBackColor = false;
            this.txtMaVoucher.Click += new System.EventHandler(this.txtMaVoucher_Click);
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblGiamGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblGiamGia.Location = new System.Drawing.Point(400, 119);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(109, 23);
            this.lblGiamGia.TabIndex = 14;
            this.lblGiamGia.Text = "Giảm giá: 0 ₫";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelBottom.Controls.Add(this.groupThanhToan);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 663);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(15, 0, 15, 15);
            this.panelBottom.Size = new System.Drawing.Size(961, 190); // Thu nhỏ panelBottom
            this.panelBottom.TabIndex = 2;
            // 
            // groupThanhToan
            // 
            this.groupThanhToan.BackColor = System.Drawing.Color.White;
            this.groupThanhToan.Controls.Add(this.label5);
            this.groupThanhToan.Controls.Add(this.txtTenKhachHang);
            this.groupThanhToan.Controls.Add(this.label6);
            this.groupThanhToan.Controls.Add(this.txtSoDienThoai);
            this.groupThanhToan.Controls.Add(this.lblDiaChi);
            this.groupThanhToan.Controls.Add(this.txtDiaChi);
            this.groupThanhToan.Controls.Add(this.lblTongTien);
            this.groupThanhToan.Controls.Add(this.btnXuatHoaDon);
            this.groupThanhToan.Controls.Add(this.btnThanhToan);
            this.groupThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupThanhToan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupThanhToan.Location = new System.Drawing.Point(15, 0);
            this.groupThanhToan.Name = "groupThanhToan";
            this.groupThanhToan.Size = new System.Drawing.Size(931, 175);
            this.groupThanhToan.TabIndex = 0;
            this.groupThanhToan.TabStop = false;
            this.groupThanhToan.Text = " Thông tin Khách hàng & Thanh Toán ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(25, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Khách hàng:";
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTenKhachHang.Location = new System.Drawing.Point(120, 32);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(250, 29);
            this.txtTenKhachHang.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(25, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Điện thoại:";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSoDienThoai.Location = new System.Drawing.Point(120, 72);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(250, 29);
            this.txtSoDienThoai.TabIndex = 3;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiaChi.Location = new System.Drawing.Point(25, 115);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(58, 20);
            this.lblDiaChi.TabIndex = 4;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiaChi.Location = new System.Drawing.Point(120, 112);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(250, 29);
            this.txtDiaChi.TabIndex = 5;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.lblTongTien.Location = new System.Drawing.Point(420, 70); // Nâng nhãn tổng tiền lên
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(164, 41);
            this.lblTongTien.TabIndex = 9;
            this.lblTongTien.Text = "TỔNG: 0 ₫";
            // 
            // btnXuatHoaDon
            // 
            this.btnXuatHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnXuatHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatHoaDon.FlatAppearance.BorderSize = 0;
            this.btnXuatHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXuatHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnXuatHoaDon.Location = new System.Drawing.Point(720, 30);
            this.btnXuatHoaDon.Name = "btnXuatHoaDon";
            this.btnXuatHoaDon.Size = new System.Drawing.Size(180, 45);
            this.btnXuatHoaDon.TabIndex = 10;
            this.btnXuatHoaDon.Text = "📄 XUẤT BILL";
            this.btnXuatHoaDon.UseVisualStyleBackColor = false;
            this.btnXuatHoaDon.Click += new System.EventHandler(this.btnXuatHoaDon_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(720, 90);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(180, 55);
            this.btnThanhToan.TabIndex = 11;
            this.btnThanhToan.Text = "THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // panelFill
            // 
            this.panelFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelFill.Controls.Add(this.dgvGioHang);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 185);
            this.panelFill.Name = "panelFill";
            this.panelFill.Padding = new System.Windows.Forms.Padding(15, 0, 15, 15);
            this.panelFill.Size = new System.Drawing.Size(961, 478);
            this.panelFill.TabIndex = 1;
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioHang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGioHang.ColumnHeadersHeight = 35;
            this.dgvGioHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGioHang.Location = new System.Drawing.Point(15, 0);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.RowHeadersWidth = 51;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(931, 463);
            this.dgvGioHang.TabIndex = 10;
            this.dgvGioHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGioHang_CellClick);
            this.dgvGioHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGioHang_CellContentClick);
            // 
            // panelHeader
            // 
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(200, 100);
            this.panelHeader.TabIndex = 3;
            this.panelHeader.Visible = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(0, 0);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(100, 29);
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.Visible = false;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(0, 0);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Visible = false;
            // 
            // btnlammoi
            // 
            this.btnlammoi.Location = new System.Drawing.Point(0, 0);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(75, 23);
            this.btnlammoi.TabIndex = 6;
            this.btnlammoi.Visible = false;
            // 
            // QuanLyHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnlammoi);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "QuanLyHoaDon";
            this.Size = new System.Drawing.Size(961, 853);
            this.Load += new System.EventHandler(this.QuanLyHoaDon_Load);
            this.panelTop.ResumeLayout(false);
            this.groupSanPham.ResumeLayout(false);
            this.groupSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.groupThanhToan.ResumeLayout(false);
            this.groupThanhToan.PerformLayout();
            this.panelFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.GroupBox groupSanPham;
        private System.Windows.Forms.GroupBox groupThanhToan;

        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.ComboBox cboMauSac;
        private System.Windows.Forms.NumericUpDown nmSoLuong;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnlammoi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnXuatHoaDon;
        private System.Windows.Forms.TextBox txtVoucher;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button txtMaVoucher;
        private System.Windows.Forms.Button btnLamMoi2;
    }
}