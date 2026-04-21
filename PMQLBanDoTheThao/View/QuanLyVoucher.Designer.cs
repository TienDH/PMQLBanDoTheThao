namespace PMQLBanDoTheThao.View
{
    partial class QuanLyVoucher
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvVoucher = new System.Windows.Forms.DataGridView();
            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.groupThongTin = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.timerTimKiem = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).BeginInit();
            this.groupThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVoucher
            // 
            this.dgvVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVoucher.Location = new System.Drawing.Point(0, 297);
            this.dgvVoucher.Name = "dgvVoucher";
            this.dgvVoucher.RowHeadersWidth = 51;
            this.dgvVoucher.RowTemplate.Height = 24;
            this.dgvVoucher.Size = new System.Drawing.Size(1292, 451);
            this.dgvVoucher.TabIndex = 9;
            // 
            // dtpExpiry
            // 
            this.dtpExpiry.Location = new System.Drawing.Point(149, 123);
            this.dtpExpiry.Name = "dtpExpiry";
            this.dtpExpiry.Size = new System.Drawing.Size(399, 22);
            this.dtpExpiry.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "hạn dùng:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(149, 75);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(399, 22);
            this.txtDiscount.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "% giảm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(462, 192);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(181, 22);
            this.txtTimKiem.TabIndex = 14;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(299, 189);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(114, 29);
            this.btnTimKiem.TabIndex = 13;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // groupThongTin
            // 
            this.groupThongTin.Controls.Add(this.dtpExpiry);
            this.groupThongTin.Controls.Add(this.label3);
            this.groupThongTin.Controls.Add(this.txtDiscount);
            this.groupThongTin.Controls.Add(this.label2);
            this.groupThongTin.Controls.Add(this.txtTimKiem);
            this.groupThongTin.Controls.Add(this.btnTimKiem);
            this.groupThongTin.Controls.Add(this.btnLamMoi);
            this.groupThongTin.Controls.Add(this.btnXoa);
            this.groupThongTin.Controls.Add(this.btnSua);
            this.groupThongTin.Controls.Add(this.btnThem);
            this.groupThongTin.Controls.Add(this.txtCode);
            this.groupThongTin.Controls.Add(this.label1);
            this.groupThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupThongTin.Location = new System.Drawing.Point(0, 28);
            this.groupThongTin.Name = "groupThongTin";
            this.groupThongTin.Size = new System.Drawing.Size(1280, 263);
            this.groupThongTin.TabIndex = 7;
            this.groupThongTin.TabStop = false;
            this.groupThongTin.Text = "Thông tin sản phẩm";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(697, 75);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(114, 37);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(571, 75);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(114, 37);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(697, 27);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(114, 37);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(571, 27);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(114, 37);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(149, 29);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(399, 22);
            this.txtCode.TabIndex = 10;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mã:";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSanPham.ColumnHeadersHeight = 29;
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSanPham.Location = new System.Drawing.Point(0, 0);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(1280, 28);
            this.dgvSanPham.TabIndex = 8;
            // 
            // timerTimKiem
            // 
            this.timerTimKiem.Interval = 400;
            // 
            // QuanLyVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.dgvVoucher);
            this.Controls.Add(this.groupThongTin);
            this.Controls.Add(this.dgvSanPham);
            this.Name = "QuanLyVoucher";
            this.Size = new System.Drawing.Size(1280, 858);
            this.Load += new System.EventHandler(this.QuanLyVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).EndInit();
            this.groupThongTin.ResumeLayout(false);
            this.groupThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVoucher;
        private System.Windows.Forms.DateTimePicker dtpExpiry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox groupThongTin;
        private System.Windows.Forms.Button btnLamMoi;
        public System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Timer timerTimKiem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
