using System.Windows.Forms;

namespace PMQLBanDoTheThao.View
{
    partial class QuanLySanPham
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerTimKiem = new System.Windows.Forms.Timer(this.components);
            this.groupThongTin = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtHinhAnh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDanhMuc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChonHinh = new System.Windows.Forms.Button();
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
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.dgvBienThe = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupThongTin.SuspendLayout();
            this.groupBienThe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBienThe)).BeginInit();
            this.SuspendLayout();
            // 
            // timerTimKiem
            // 
            this.timerTimKiem.Interval = 400;
            this.timerTimKiem.Tick += new System.EventHandler(this.timerTimKiem_Tick_1);
            // 
            // groupThongTin
            // 
            this.groupThongTin.Controls.Add(this.txtTimKiem);
            this.groupThongTin.Controls.Add(this.btnTimKiem);
            this.groupThongTin.Controls.Add(this.btnLamMoi);
            this.groupThongTin.Controls.Add(this.btnXoa);
            this.groupThongTin.Controls.Add(this.btnSua);
            this.groupThongTin.Controls.Add(this.btnThem);
            this.groupThongTin.Controls.Add(this.txtHinhAnh);
            this.groupThongTin.Controls.Add(this.label4);
            this.groupThongTin.Controls.Add(this.txtGiaBan);
            this.groupThongTin.Controls.Add(this.label3);
            this.groupThongTin.Controls.Add(this.cmbDanhMuc);
            this.groupThongTin.Controls.Add(this.label2);
            this.groupThongTin.Controls.Add(this.txtTenSanPham);
            this.groupThongTin.Controls.Add(this.label1);
            this.groupThongTin.Controls.Add(this.btnChonHinh);
            this.groupThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupThongTin.Location = new System.Drawing.Point(0, 0);
            this.groupThongTin.Name = "groupThongTin";
            this.groupThongTin.Size = new System.Drawing.Size(961, 213);
            this.groupThongTin.TabIndex = 0;
            this.groupThongTin.TabStop = false;
            this.groupThongTin.Text = "Thông tin sản phẩm";
            this.groupThongTin.Enter += new System.EventHandler(this.groupThongTin_Enter);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(691, 146);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(181, 22);
            this.txtTimKiem.TabIndex = 14;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged_1);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(571, 144);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(114, 29);
            this.btnTimKiem.TabIndex = 13;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click_1);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(697, 75);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(114, 37);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click_1);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(571, 75);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(114, 37);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click_1);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(697, 27);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(114, 37);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click_1);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(571, 27);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(114, 37);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // txtHinhAnh
            // 
            this.txtHinhAnh.Location = new System.Drawing.Point(149, 141);
            this.txtHinhAnh.Name = "txtHinhAnh";
            this.txtHinhAnh.Size = new System.Drawing.Size(249, 22);
            this.txtHinhAnh.TabIndex = 4;
            this.txtHinhAnh.TextChanged += new System.EventHandler(this.txtHinhAnh_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hình ảnh:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(149, 103);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(171, 22);
            this.txtGiaBan.TabIndex = 6;
            this.txtGiaBan.TextChanged += new System.EventHandler(this.txtGiaBan_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Giá bán:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmbDanhMuc
            // 
            this.cmbDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDanhMuc.Location = new System.Drawing.Point(149, 66);
            this.cmbDanhMuc.Name = "cmbDanhMuc";
            this.cmbDanhMuc.Size = new System.Drawing.Size(399, 24);
            this.cmbDanhMuc.TabIndex = 8;
            this.cmbDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cmbDanhMuc_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Danh mục:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Location = new System.Drawing.Point(149, 29);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(399, 22);
            this.txtTenSanPham.TabIndex = 10;
            this.txtTenSanPham.TextChanged += new System.EventHandler(this.txtTenSanPham_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tên sản phẩm:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnChonHinh
            // 
            this.btnChonHinh.Location = new System.Drawing.Point(416, 141);
            this.btnChonHinh.Name = "btnChonHinh";
            this.btnChonHinh.Size = new System.Drawing.Size(103, 27);
            this.btnChonHinh.TabIndex = 12;
            this.btnChonHinh.Text = "Chọn Hình";
            this.btnChonHinh.Click += new System.EventHandler(this.btnChonHinh_Click_1);
            // 
            // groupBienThe
            // 
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
            this.groupBienThe.Location = new System.Drawing.Point(0, 213);
            this.groupBienThe.Name = "groupBienThe";
            this.groupBienThe.Size = new System.Drawing.Size(961, 107);
            this.groupBienThe.TabIndex = 1;
            this.groupBienThe.TabStop = false;
            this.groupBienThe.Text = "Thêm biến thể (Size - Màu)";
            this.groupBienThe.Enter += new System.EventHandler(this.groupBienThe_Enter);
            // 
            // btnXoaBienThe
            // 
            this.btnXoaBienThe.Location = new System.Drawing.Point(794, 24);
            this.btnXoaBienThe.Name = "btnXoaBienThe";
            this.btnXoaBienThe.Size = new System.Drawing.Size(91, 32);
            this.btnXoaBienThe.TabIndex = 8;
            this.btnXoaBienThe.Text = "Xóa";
            this.btnXoaBienThe.Click += new System.EventHandler(this.btnXoaBienThe_Click_1);
            // 
            // btnSuaBienThe
            // 
            this.btnSuaBienThe.Location = new System.Drawing.Point(697, 24);
            this.btnSuaBienThe.Name = "btnSuaBienThe";
            this.btnSuaBienThe.Size = new System.Drawing.Size(91, 32);
            this.btnSuaBienThe.TabIndex = 7;
            this.btnSuaBienThe.Text = "Sửa";
            this.btnSuaBienThe.Click += new System.EventHandler(this.btnSuaBienThe_Click_1);
            // 
            // btnThemBienThe
            // 
            this.btnThemBienThe.Location = new System.Drawing.Point(594, 24);
            this.btnThemBienThe.Name = "btnThemBienThe";
            this.btnThemBienThe.Size = new System.Drawing.Size(91, 32);
            this.btnThemBienThe.TabIndex = 0;
            this.btnThemBienThe.Text = "Thêm";
            this.btnThemBienThe.Click += new System.EventHandler(this.btnThemBienThe_Click_1);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(106, 65);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(91, 22);
            this.txtSoLuong.TabIndex = 1;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtSoLuong_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Số lượng:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // cmbMau
            // 
            this.cmbMau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMau.Location = new System.Drawing.Point(400, 29);
            this.cmbMau.Name = "cmbMau";
            this.cmbMau.Size = new System.Drawing.Size(171, 24);
            this.cmbMau.TabIndex = 3;
            this.cmbMau.SelectedIndexChanged += new System.EventHandler(this.cmbMau_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Màu sắc:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // cmbSize
            // 
            this.cmbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSize.Location = new System.Drawing.Point(91, 29);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(171, 24);
            this.cmbSize.TabIndex = 5;
            this.cmbSize.SelectedIndexChanged += new System.EventHandler(this.cmbSize_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Size:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.ColumnHeadersHeight = 29;
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSanPham.Location = new System.Drawing.Point(0, 320);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(961, 267);
            this.dgvSanPham.TabIndex = 1;
            this.dgvSanPham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellContentClick);
            // 
            // dgvBienThe
            // 
            this.dgvBienThe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvBienThe.ColumnHeadersHeight = 29;
            this.dgvBienThe.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvBienThe.Location = new System.Drawing.Point(0, 587);
            this.dgvBienThe.Name = "dgvBienThe";
            this.dgvBienThe.RowHeadersWidth = 51;
            this.dgvBienThe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBienThe.Size = new System.Drawing.Size(961, 192);
            this.dgvBienThe.TabIndex = 0;
            this.dgvBienThe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBienThe_CellContentClick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // QuanLySanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.dgvBienThe);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.groupBienThe);
            this.Controls.Add(this.groupThongTin);
            this.Name = "QuanLySanPham";
            this.Size = new System.Drawing.Size(961, 853);
            this.groupThongTin.ResumeLayout(false);
            this.groupThongTin.PerformLayout();
            this.groupBienThe.ResumeLayout(false);
            this.groupBienThe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBienThe)).EndInit();
            this.ResumeLayout(false);

        }


        // ==================== CONTROLS DECLARATION ====================
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
        private Button btnXoaBienThe;
        private Button btnSuaBienThe;
        private Button btnTimKiem;
        private Button btnSua;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox txtTimKiem;
        private System.Windows.Forms.Timer timerTimKiem;
    }
}
