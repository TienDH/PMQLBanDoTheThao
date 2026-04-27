using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq; // Thư viện cực kỳ quan trọng để lọc dữ liệu (LINQ)
using System.Windows.Forms;
using PMQLBanDoTheThao.Controller;
using PMQLBanDoTheThao.Model;

namespace PMQLBanDoTheThao.View
{
    public partial class TrangChu : UserControl
    {
        private QuanLySanPhamController _controller;

        // Biến cờ (flag) để tránh việc Filter chạy lúc ComboBox đang khởi tạo
        private bool isLoaded = false;

        public TrangChu()
        {
            InitializeComponent();
            _controller = new QuanLySanPhamController();

            // Đăng ký sự kiện: Cứ đổi lựa chọn ở Dropdown là tự động lọc luôn (Không cần bấm nút)
            cmbLoai.SelectedIndexChanged += Filter_Changed;
            cmbGia.SelectedIndexChanged += Filter_Changed;
            cmbSapXep.SelectedIndexChanged += Filter_Changed;
        }

        // ================== SỰ KIỆN LOAD TRANG ==================
        private void TrangChu_Load(object sender, EventArgs e)
        {
            LoadComboBoxData(); // Nạp dữ liệu cho các thanh Dropdown
            isLoaded = true;    // Đánh dấu đã load xong giao diện
            ThucHienLoc();      // Load toàn bộ sản phẩm lần đầu tiên
        }

        // ================== CẤU HÌNH CÁC THANH COMBOBOX ==================
        private void LoadComboBoxData()
        {
            // 1. Nạp danh sách Thể loại từ Database
            DataTable dtCat = _controller.GetAllCategories();
            DataRow dr = dtCat.NewRow();
            dr["Id"] = 0;
            dr["CategoryName"] = "--- Tất cả thể loại ---";
            dtCat.Rows.InsertAt(dr, 0); // Chèn dòng "Tất cả" lên đầu tiên

            cmbLoai.DataSource = dtCat;
            cmbLoai.DisplayMember = "CategoryName";
            cmbLoai.ValueMember = "Id";

            // 2. Nạp dữ liệu cứng cho thanh Mức Giá
            cmbGia.Items.Clear();
            cmbGia.Items.Add("--- Mức giá ---");
            cmbGia.Items.Add("Dưới 500.000 ₫");
            cmbGia.Items.Add("500.000 ₫ - 1.000.000 ₫");
            cmbGia.Items.Add("Trên 1.000.000 ₫");
            cmbGia.SelectedIndex = 0;

            // 3. Nạp dữ liệu cứng cho thanh Sắp xếp
            cmbSapXep.Items.Clear();
            cmbSapXep.Items.Add("--- Sắp xếp ---");
            cmbSapXep.Items.Add("Giá tăng dần");
            cmbSapXep.Items.Add("Giá giảm dần");
            cmbSapXep.SelectedIndex = 0;
        }

        // ================== LÕI TÌM KIẾM VÀ LỌC DỮ LIỆU CHUYÊN NGHIỆP ==================
        private void ThucHienLoc()
        {
            if (!isLoaded) return; // Nếu form chưa load xong thì không làm gì cả

            // 1. LẤY TỪ KHÓA TÌM KIẾM
            string tuKhoa = txtTimKiem.Text.Trim();
            if (tuKhoa == "🔍 Nhập tên sản phẩm...") tuKhoa = "";

            // 2. TRUY VẤN CƠ BẢN TỪ DATABASE (Sử dụng code bạn đã viết sẵn)
            List<Product> ketQua = string.IsNullOrEmpty(tuKhoa)
                ? _controller.GetAllProducts()
                : _controller.SearchProducts(tuKhoa);

            // 3. LỌC THEO THỂ LOẠI (Sử dụng LINQ)
            if (cmbLoai.SelectedValue != null && (int)cmbLoai.SelectedValue > 0)
            {
                int catId = (int)cmbLoai.SelectedValue;
                ketQua = ketQua.Where(p => p.CategoryId == catId).ToList();
            }

            // 4. LỌC THEO MỨC GIÁ
            int giaIndex = cmbGia.SelectedIndex;
            if (giaIndex == 1) // Dưới 500k
                ketQua = ketQua.Where(p => p.Price < 500000).ToList();
            else if (giaIndex == 2) // Từ 500k đến 1 Triệu
                ketQua = ketQua.Where(p => p.Price >= 500000 && p.Price <= 1000000).ToList();
            else if (giaIndex == 3) // Trên 1 Triệu
                ketQua = ketQua.Where(p => p.Price > 1000000).ToList();

            // 5. SẮP XẾP GIÁ
            int sortIndex = cmbSapXep.SelectedIndex;
            if (sortIndex == 1) // Tăng dần
                ketQua = ketQua.OrderBy(p => p.Price).ToList();
            else if (sortIndex == 2) // Giảm dần
                ketQua = ketQua.OrderByDescending(p => p.Price).ToList();

            // 6. HIỂN THỊ KẾT QUẢ CUỐI CÙNG LÊN GIAO DIỆN
            HienThiDanhSachSanPham(ketQua);
        }

        // Sự kiện dùng chung cho các ComboBox (Chỉ cần chọn là lọc)
        private void Filter_Changed(object sender, EventArgs e)
        {
            ThucHienLoc();
        }

        // Bấm nút Tìm kiếm cũng gọi hàm Lọc
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ThucHienLoc();
        }

        // ================== HÀM VẼ GIAO DIỆN ==================
        private void HienThiDanhSachSanPham(List<Product> danhSach)
        {
            flowLayoutPanel1.Controls.Clear(); // Xóa sạch thẻ cũ

            // Nếu không có sản phẩm nào
            if (danhSach.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "Không tìm thấy sản phẩm nào phù hợp!",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = System.Drawing.Color.Gray,
                    Margin = new Padding(20)
                };
                flowLayoutPanel1.Controls.Add(lblEmpty);
                return;
            }

            // Vẽ từng thẻ sản phẩm
            foreach (var p in danhSach)
            {
                flowLayoutPanel1.Controls.Add(CreateProductCard(p));
            }
        }

        // ================== TẠO HIỆU ỨNG CHO Ô TÌM KIẾM ==================
        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "🔍 Nhập tên sản phẩm...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "🔍 Nhập tên sản phẩm...";
                txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            }
        }

        // ================== THIẾT KẾ THẺ SẢN PHẨM ==================
        private Panel CreateProductCard(Product p)
        {
            Panel card = new Panel
            {
                Width = 190,
                Height = 290,
                Margin = new Padding(10, 10, 15, 15),
                BackColor = System.Drawing.Color.White,
                Cursor = Cursors.Hand
            };

            PictureBox pic = new PictureBox
            {
                Width = 170,
                Height = 140,
                Top = 10,
                Left = 10,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            if (!string.IsNullOrEmpty(p.ImagePath) && File.Exists(p.ImagePath))
                pic.Image = Image.FromFile(p.ImagePath);

            Label name = new Label
            {
                Text = p.Name,
                Top = 155,
                Left = 10,
                Width = 170,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(40, 40, 40),
                AutoEllipsis = true
            };

            Label cate = new Label
            {
                Text = p.CategoryName,
                Top = 178,
                Left = 10,
                Width = 170,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
                ForeColor = System.Drawing.Color.Gray
            };

            Label price = new Label
            {
                Text = p.Price.ToString("N0") + " ₫",
                Top = 200,
                Left = 10,
                Width = 170,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(238, 77, 45)
            };

            Button btn = new Button
            {
                Text = "MUA NGAY",
                Top = 235,
                Left = 10,
                Width = 170,
                Height = 35,
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(238, 77, 45),
                ForeColor = System.Drawing.Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) =>
            {
                // 1. Tìm cái Form chính (MainMenu) đang chứa Trang chủ này
                MainMenu mainForm = this.FindForm() as MainMenu;

                if (mainForm != null)
                {
                    // 2. Nhờ MainMenu chuyển trang và ném Id của sản phẩm sang
                    mainForm.ChuyenSangTrangHoaDon(p.Id);
                }
            };

            // Hiệu ứng Hover
            EventHandler hoverEnter = (s, e) => { card.BackColor = System.Drawing.Color.FromArgb(248, 249, 250); };
            EventHandler hoverLeave = (s, e) => { card.BackColor = System.Drawing.Color.White; };

            card.MouseEnter += hoverEnter; card.MouseLeave += hoverLeave;
            pic.MouseEnter += hoverEnter; pic.MouseLeave += hoverLeave;
            name.MouseEnter += hoverEnter; name.MouseLeave += hoverLeave;
            cate.MouseEnter += hoverEnter; cate.MouseLeave += hoverLeave;
            price.MouseEnter += hoverEnter; price.MouseLeave += hoverLeave;

            card.Controls.Add(pic);
            card.Controls.Add(name);
            card.Controls.Add(cate);
            card.Controls.Add(price);
            card.Controls.Add(btn);

            return card;
        }

        private void cmbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

