namespace PMQLBanDoTheThao
{
    partial class MainMenu
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelLeft = new System.Windows.Forms.Panel();

            // Các nút được sắp xếp lại theo logic công việc
            this.btnTrangchu = new System.Windows.Forms.Button();
            this.btnQuanLyHoaDon = new System.Windows.Forms.Button();
            this.btnQuanLySanPham = new System.Windows.Forms.Button();
            this.btnLoaiSP = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button(); // Voucher
            this.btnQuanLyKhachHang = new System.Windows.Forms.Button();
            this.btnQuanLyNhanVien = new System.Windows.Forms.Button();
            this.BtnQuanLyKho = new System.Windows.Forms.Button();
            this.btnThongKeBaoCao = new System.Windows.Forms.Button();

            this.panel3 = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();

            this.panelTop = new System.Windows.Forms.Panel();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.panelTopBorder = new System.Windows.Forms.Panel();

            this.panelMain = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.panelLeft.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelTop.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();

            // ==========================================
            // 1. THANH MENU TRÁI (Sidebar - Dark Mode)
            // ==========================================
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.panelLeft.Controls.Add(this.btnThongKeBaoCao);
            this.panelLeft.Controls.Add(this.BtnQuanLyKho);
            this.panelLeft.Controls.Add(this.btnQuanLyNhanVien);
            this.panelLeft.Controls.Add(this.btnQuanLyKhachHang);
            this.panelLeft.Controls.Add(this.button1); // Voucher
            this.panelLeft.Controls.Add(this.btnLoaiSP);
            this.panelLeft.Controls.Add(this.btnQuanLySanPham);
            this.panelLeft.Controls.Add(this.btnQuanLyHoaDon);
            this.panelLeft.Controls.Add(this.btnTrangchu);
            this.panelLeft.Controls.Add(this.panel3); // Logo
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(240, 787);
            this.panelLeft.TabIndex = 0;

            // 
            // KHU VỰC LOGO (Màu Cam)
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.panel3.Controls.Add(this.picLogo);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 75);
            this.panel3.TabIndex = 2;

            this.picLogo.Location = new System.Drawing.Point(15, 17);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(40, 40);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(60, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "SPORT STORE";

            // ==========================================
            // CẤU HÌNH CHUNG CHO CÁC NÚT (BUTTONS)
            // ==========================================
            // btnTrangchu
            this.btnTrangchu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrangchu.FlatAppearance.BorderSize = 0;
            this.btnTrangchu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnTrangchu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangchu.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnTrangchu.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTrangchu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangchu.Location = new System.Drawing.Point(0, 75);
            this.btnTrangchu.Name = "btnTrangchu";
            this.btnTrangchu.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTrangchu.Size = new System.Drawing.Size(240, 55);
            this.btnTrangchu.TabIndex = 8;
            this.btnTrangchu.Text = "  Trang Chủ"; // Khoảng trắng để chừa chỗ cho Icon
            this.btnTrangchu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangchu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrangchu.Click += new System.EventHandler(this.btnTrangchu_Click);

            // btnQuanLyHoaDon (Đưa lên thứ 2 vì dùng nhiều nhất)
            this.btnQuanLyHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyHoaDon.FlatAppearance.BorderSize = 0;
            this.btnQuanLyHoaDon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnQuanLyHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyHoaDon.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnQuanLyHoaDon.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQuanLyHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyHoaDon.Location = new System.Drawing.Point(0, 130);
            this.btnQuanLyHoaDon.Name = "btnQuanLyHoaDon";
            this.btnQuanLyHoaDon.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnQuanLyHoaDon.Size = new System.Drawing.Size(240, 55);
            this.btnQuanLyHoaDon.TabIndex = 6;
            this.btnQuanLyHoaDon.Text = "  Hóa Đơn / Bán Hàng";
            this.btnQuanLyHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyHoaDon.Click += new System.EventHandler(this.btnQuanLyHoaDon_Click);

            // btnQuanLySanPham
            this.btnQuanLySanPham.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLySanPham.FlatAppearance.BorderSize = 0;
            this.btnQuanLySanPham.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnQuanLySanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLySanPham.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnQuanLySanPham.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQuanLySanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLySanPham.Location = new System.Drawing.Point(0, 185);
            this.btnQuanLySanPham.Name = "btnQuanLySanPham";
            this.btnQuanLySanPham.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnQuanLySanPham.Size = new System.Drawing.Size(240, 55);
            this.btnQuanLySanPham.TabIndex = 7;
            this.btnQuanLySanPham.Text = "  Sản Phẩm";
            this.btnQuanLySanPham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLySanPham.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLySanPham.Click += new System.EventHandler(this.btnQuanLySanPham_Click_1);

            // btnLoaiSP
            this.btnLoaiSP.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoaiSP.FlatAppearance.BorderSize = 0;
            this.btnLoaiSP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnLoaiSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoaiSP.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnLoaiSP.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLoaiSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoaiSP.Location = new System.Drawing.Point(0, 240);
            this.btnLoaiSP.Name = "btnLoaiSP";
            this.btnLoaiSP.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLoaiSP.Size = new System.Drawing.Size(240, 55);
            this.btnLoaiSP.TabIndex = 1;
            this.btnLoaiSP.Text = "  Loại Sản Phẩm";
            this.btnLoaiSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoaiSP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoaiSP.Click += new System.EventHandler(this.btnLoaiSP_Click);

            // button1 (Voucher)
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 295);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(240, 55);
            this.button1.TabIndex = 0;
            this.button1.Text = "  Khuyến Mãi (Voucher)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // btnQuanLyKhachHang
            this.btnQuanLyKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyKhachHang.FlatAppearance.BorderSize = 0;
            this.btnQuanLyKhachHang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnQuanLyKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyKhachHang.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnQuanLyKhachHang.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQuanLyKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyKhachHang.Location = new System.Drawing.Point(0, 350);
            this.btnQuanLyKhachHang.Name = "btnQuanLyKhachHang";
            this.btnQuanLyKhachHang.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnQuanLyKhachHang.Size = new System.Drawing.Size(240, 55);
            this.btnQuanLyKhachHang.TabIndex = 5;
            this.btnQuanLyKhachHang.Text = "  Khách Hàng";
            this.btnQuanLyKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyKhachHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyKhachHang.Click += new System.EventHandler(this.btnQuanLyKhachHang_Click);

            // btnQuanLyNhanVien
            this.btnQuanLyNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyNhanVien.FlatAppearance.BorderSize = 0;
            this.btnQuanLyNhanVien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnQuanLyNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyNhanVien.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnQuanLyNhanVien.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnQuanLyNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyNhanVien.Location = new System.Drawing.Point(0, 405);
            this.btnQuanLyNhanVien.Name = "btnQuanLyNhanVien";
            this.btnQuanLyNhanVien.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnQuanLyNhanVien.Size = new System.Drawing.Size(240, 55);
            this.btnQuanLyNhanVien.TabIndex = 4;
            this.btnQuanLyNhanVien.Text = "  Nhân Viên";
            this.btnQuanLyNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyNhanVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyNhanVien.Click += new System.EventHandler(this.btnQuanLyNhanVien_Click);

            // BtnQuanLyKho
            this.BtnQuanLyKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnQuanLyKho.FlatAppearance.BorderSize = 0;
            this.BtnQuanLyKho.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.BtnQuanLyKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQuanLyKho.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.BtnQuanLyKho.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnQuanLyKho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuanLyKho.Location = new System.Drawing.Point(0, 460);
            this.BtnQuanLyKho.Name = "BtnQuanLyKho";
            this.BtnQuanLyKho.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnQuanLyKho.Size = new System.Drawing.Size(240, 55);
            this.BtnQuanLyKho.TabIndex = 3;
            this.BtnQuanLyKho.Text = "  Kho Hàng";
            this.BtnQuanLyKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuanLyKho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnQuanLyKho.Click += new System.EventHandler(this.BtnQuanLyKho_Click);

            // btnThongKeBaoCao
            this.btnThongKeBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKeBaoCao.FlatAppearance.BorderSize = 0;
            this.btnThongKeBaoCao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            this.btnThongKeBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKeBaoCao.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnThongKeBaoCao.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnThongKeBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKeBaoCao.Location = new System.Drawing.Point(0, 515);
            this.btnThongKeBaoCao.Name = "btnThongKeBaoCao";
            this.btnThongKeBaoCao.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnThongKeBaoCao.Size = new System.Drawing.Size(240, 55);
            this.btnThongKeBaoCao.TabIndex = 2;
            this.btnThongKeBaoCao.Text = "  Thống Kê Báo Cáo";
            this.btnThongKeBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKeBaoCao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKeBaoCao.Click += new System.EventHandler(this.btnThongKeBaoCao_Click);


            // ==========================================
            // 2. THANH TOP BAR (Màu Trắng, Nút Đăng Nhập)
            // ==========================================
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btnDangNhap);
            this.panelTop.Controls.Add(this.lblPageTitle);
            this.panelTop.Controls.Add(this.panelTopBorder);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(240, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1197, 75); // Chiều cao bằng Logo
            this.panelTop.TabIndex = 1;

            // lblPageTitle (Tiêu đề trang ở TopBar)
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblPageTitle.Location = new System.Drawing.Point(25, 18);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(171, 37);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "HỆ THỐNG";

            // btnDangNhap
            this.btnDangNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(1030, 17);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(130, 40);
            this.btnDangNhap.TabIndex = 0;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click_1);

            // panelTopBorder (Đường kẻ dưới mỏng 1px)
            this.panelTopBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panelTopBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTopBorder.Location = new System.Drawing.Point(0, 74);
            this.panelTopBorder.Name = "panelTopBorder";
            this.panelTopBorder.Size = new System.Drawing.Size(1197, 1);
            this.panelTopBorder.TabIndex = 3;

            // ==========================================
            // 3. KHU VỰC HIỂN THỊ CHÍNH (panelMain)
            // ==========================================
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(240, 75);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1197, 712);
            this.panelMain.TabIndex = 2;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);

            // contextMenuStrip1
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(86, 28);

            // zToolStripMenuItem
            this.zToolStripMenuItem.Name = "zToolStripMenuItem";
            this.zToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.zToolStripMenuItem.Text = "z";

            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 787);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeft);
            this.Name = "MainMenu";
            this.Text = "Phần Mềm Quản Lý Bán Đồ Thể Thao";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.panelLeft.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem zToolStripMenuItem;
        private System.Windows.Forms.Button btnQuanLySanPham;
        private System.Windows.Forms.Button btnThongKeBaoCao;
        private System.Windows.Forms.Button BtnQuanLyKho;
        private System.Windows.Forms.Button btnQuanLyNhanVien;
        private System.Windows.Forms.Button btnQuanLyKhachHang;
        private System.Windows.Forms.Button btnQuanLyHoaDon;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnLoaiSP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTrangchu;

        // Thêm biến để dùng cho giao diện mới
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel panelTopBorder;
    }
}