namespace PMQLBanDoTheThao.View
{
    partial class QuanLySanPham
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
            this.components = new System.ComponentModel.Container();
            this.panelTopSearch = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panelFill = new System.Windows.Forms.Panel();
            this.dgvBienThe = new System.Windows.Forms.DataGridView();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.groupBienThe = new System.Windows.Forms.GroupBox();
            this.btnXoaBienThe = new System.Windows.Forms.Button();
            this.btnSuaBienThe = new System.Windows.Forms.Button();
            this.btnThemBienThe = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbMau = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupThongTin = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnChonHinh = new System.Windows.Forms.Button();
            this.txtHinhAnh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDanhMuc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerTimKiem = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelTopSearch.SuspendLayout();
            this.panelFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBienThe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.groupBienThe.SuspendLayout();
            this.groupThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopSearch
            // 
            this.panelTopSearch.BackColor = System.Drawing.Color.White;
            this.panelTopSearch.Controls.Add(this.txtTimKiem);
            this.panelTopSearch.Controls.Add(this.btnTimKiem);
            this.panelTopSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopSearch.Location = new System.Drawing.Point(0, 0);
            this.panelTopSearch.Name = "panelTopSearch";
            this.panelTopSearch.Size = new System.Drawing.Size(961, 60);
            this.panelTopSearch.TabIndex = 3;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(150, 14);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 30);
            this.txtTimKiem.TabIndex = 14;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(15, 12);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(114, 32);
            this.btnTimKiem.TabIndex = 13;
            this.btnTimKiem.Text = "TÌM KIẾM";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // panelFill
            // 
            this.panelFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelFill.Controls.Add(this.dgvBienThe);
            this.panelFill.Controls.Add(this.dgvSanPham);
            this.panelFill.Controls.Add(this.groupBienThe);
            this.panelFill.Controls.Add(this.groupThongTin);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 60);
            this.panelFill.Name = "panelFill";
            this.panelFill.Padding = new System.Windows.Forms.Padding(15);
            this.panelFill.Size = new System.Drawing.Size(961, 793);
            this.panelFill.TabIndex = 4;
            // 
            // dgvBienThe
            // 
            this.dgvBienThe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBienThe.BackgroundColor = System.Drawing.Color.White;
            this.dgvBienThe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBienThe.ColumnHeadersHeight = 35;
            this.dgvBienThe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBienThe.Location = new System.Drawing.Point(15, 515);
            this.dgvBienThe.Name = "dgvBienThe";
            this.dgvBienThe.ReadOnly = true;
            this.dgvBienThe.RowHeadersWidth = 51;
            this.dgvBienThe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBienThe.Size = new System.Drawing.Size(931, 263);
            this.dgvBienThe.TabIndex = 0;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSanPham.ColumnHeadersHeight = 35;
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSanPham.Location = new System.Drawing.Point(15, 265);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(931, 250);
            this.dgvSanPham.TabIndex = 1;
            // 
            // groupBienThe
            // 
            this.groupBienThe.BackColor = System.Drawing.Color.White;
            this.groupBienThe.Controls.Add(this.btnXoaBienThe);
            this.groupBienThe.Controls.Add(this.btnSuaBienThe);
            this.groupBienThe.Controls.Add(this.btnThemBienThe);
            this.groupBienThe.Controls.Add(this.txtSoLuong);
            this.groupBienThe.Controls.Add(this.label7);
            this.groupBienThe.Controls.Add(this.cmbMau);
            this.groupBienThe.Controls.Add(this.label6);
            this.groupBienThe.Controls.Add(this.cmbSize);
            this.groupBienThe.Controls.Add(this.label5);
            this.groupBienThe.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBienThe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBienThe.Location = new System.Drawing.Point(15, 175);
            this.groupBienThe.Name = "groupBienThe";
            this.groupBienThe.Size = new System.Drawing.Size(931, 90);
            this.groupBienThe.TabIndex = 1;
            this.groupBienThe.TabStop = false;
            this.groupBienThe.Text = " Thuộc tính (Size - Màu - Số lượng) ";
            // 
            // btnXoaBienThe
            // 
            this.btnXoaBienThe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnXoaBienThe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaBienThe.FlatAppearance.BorderSize = 0;
            this.btnXoaBienThe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaBienThe.ForeColor = System.Drawing.Color.White;
            this.btnXoaBienThe.Location = new System.Drawing.Point(770, 32);
            this.btnXoaBienThe.Name = "btnXoaBienThe";
            this.btnXoaBienThe.Size = new System.Drawing.Size(90, 35);
            this.btnXoaBienThe.TabIndex = 0;
            this.btnXoaBienThe.Text = "Xóa";
            this.btnXoaBienThe.UseVisualStyleBackColor = false;
            this.btnXoaBienThe.Click += new System.EventHandler(this.btnXoaBienThe_Click);
            // 
            // btnSuaBienThe
            // 
            this.btnSuaBienThe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnSuaBienThe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaBienThe.FlatAppearance.BorderSize = 0;
            this.btnSuaBienThe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaBienThe.ForeColor = System.Drawing.Color.White;
            this.btnSuaBienThe.Location = new System.Drawing.Point(665, 32);
            this.btnSuaBienThe.Name = "btnSuaBienThe";
            this.btnSuaBienThe.Size = new System.Drawing.Size(90, 35);
            this.btnSuaBienThe.TabIndex = 1;
            this.btnSuaBienThe.Text = "Sửa";
            this.btnSuaBienThe.UseVisualStyleBackColor = false;
            this.btnSuaBienThe.Click += new System.EventHandler(this.btnSuaBienThe_Click);
            // 
            // btnThemBienThe
            // 
            this.btnThemBienThe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnThemBienThe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemBienThe.FlatAppearance.BorderSize = 0;
            this.btnThemBienThe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemBienThe.ForeColor = System.Drawing.Color.White;
            this.btnThemBienThe.Location = new System.Drawing.Point(560, 32);
            this.btnThemBienThe.Name = "btnThemBienThe";
            this.btnThemBienThe.Size = new System.Drawing.Size(90, 35);
            this.btnThemBienThe.TabIndex = 2;
            this.btnThemBienThe.Text = "Thêm";
            this.btnThemBienThe.UseVisualStyleBackColor = false;
            this.btnThemBienThe.Click += new System.EventHandler(this.btnThemBienThe_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSoLuong.Location = new System.Drawing.Point(450, 37);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(70, 27);
            this.txtSoLuong.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(380, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Số lượng:";
            // 
            // cmbMau
            // 
            this.cmbMau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbMau.Location = new System.Drawing.Point(260, 37);
            this.cmbMau.Name = "cmbMau";
            this.cmbMau.Size = new System.Drawing.Size(100, 28);
            this.cmbMau.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(190, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Màu sắc:";
            // 
            // cmbSize
            // 
            this.cmbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSize.Location = new System.Drawing.Point(70, 37);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(100, 28);
            this.cmbSize.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(25, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Size:";
            // 
            // groupThongTin
            // 
            this.groupThongTin.BackColor = System.Drawing.Color.White;
            this.groupThongTin.Controls.Add(this.btnLamMoi);
            this.groupThongTin.Controls.Add(this.btnXoa);
            this.groupThongTin.Controls.Add(this.btnSua);
            this.groupThongTin.Controls.Add(this.btnThem);
            this.groupThongTin.Controls.Add(this.btnChonHinh);
            this.groupThongTin.Controls.Add(this.txtHinhAnh);
            this.groupThongTin.Controls.Add(this.label4);
            this.groupThongTin.Controls.Add(this.txtGiaBan);
            this.groupThongTin.Controls.Add(this.label3);
            this.groupThongTin.Controls.Add(this.cmbDanhMuc);
            this.groupThongTin.Controls.Add(this.label2);
            this.groupThongTin.Controls.Add(this.txtTenSanPham);
            this.groupThongTin.Controls.Add(this.label1);
            this.groupThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupThongTin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupThongTin.Location = new System.Drawing.Point(15, 15);
            this.groupThongTin.Name = "groupThongTin";
            this.groupThongTin.Size = new System.Drawing.Size(931, 160);
            this.groupThongTin.TabIndex = 0;
            this.groupThongTin.TabStop = false;
            this.groupThongTin.Text = " Thông tin Sản Phẩm ";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Gray;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(645, 95);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 40);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(530, 95);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 40);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(645, 35);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 40);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(530, 35);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 40);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnChonHinh
            // 
            this.btnChonHinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnChonHinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChonHinh.FlatAppearance.BorderSize = 0;
            this.btnChonHinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonHinh.ForeColor = System.Drawing.Color.White;
            this.btnChonHinh.Location = new System.Drawing.Point(760, 35);
            this.btnChonHinh.Name = "btnChonHinh";
            this.btnChonHinh.Size = new System.Drawing.Size(100, 100);
            this.btnChonHinh.TabIndex = 4;
            this.btnChonHinh.Text = "Chọn Hình";
            this.btnChonHinh.UseVisualStyleBackColor = false;
            this.btnChonHinh.Click += new System.EventHandler(this.btnChonHinh_Click);
            // 
            // txtHinhAnh
            // 
            this.txtHinhAnh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHinhAnh.Location = new System.Drawing.Point(340, 117);
            this.txtHinhAnh.Name = "txtHinhAnh";
            this.txtHinhAnh.Size = new System.Drawing.Size(145, 27);
            this.txtHinhAnh.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(270, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hình ảnh:";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGiaBan.Location = new System.Drawing.Point(135, 117);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(120, 27);
            this.txtGiaBan.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(25, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Giá bán:";
            // 
            // cmbDanhMuc
            // 
            this.cmbDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbDanhMuc.Location = new System.Drawing.Point(135, 77);
            this.cmbDanhMuc.Name = "cmbDanhMuc";
            this.cmbDanhMuc.Size = new System.Drawing.Size(350, 28);
            this.cmbDanhMuc.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(25, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Danh mục:";
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenSanPham.Location = new System.Drawing.Point(135, 37);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(350, 27);
            this.txtTenSanPham.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(25, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tên sản phẩm:";
            // 
            // timerTimKiem
            // 
            this.timerTimKiem.Interval = 400;
            this.timerTimKiem.Tick += new System.EventHandler(this.timerTimKiem_Tick);
            // 
            // QuanLySanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelTopSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "QuanLySanPham";
            this.Size = new System.Drawing.Size(961, 853);
            this.panelTopSearch.ResumeLayout(false);
            this.panelTopSearch.PerformLayout();
            this.panelFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBienThe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.groupBienThe.ResumeLayout(false);
            this.groupBienThe.PerformLayout();
            this.groupThongTin.ResumeLayout(false);
            this.groupThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        // ==================== CONTROLS DECLARATION ====================
        private System.Windows.Forms.Panel panelTopSearch;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.GroupBox groupThongTin;
        private System.Windows.Forms.GroupBox groupBienThe;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.TextBox txtHinhAnh;
        private System.Windows.Forms.TextBox txtSoLuong;

        private System.Windows.Forms.ComboBox cmbDanhMuc;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.ComboBox cmbMau;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThemBienThe;

        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.DataGridView dgvBienThe;
        private System.Windows.Forms.Button btnChonHinh;
        private System.Windows.Forms.Button btnXoaBienThe;
        private System.Windows.Forms.Button btnSuaBienThe;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnSua;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Timer timerTimKiem;

        #endregion
    }
}
