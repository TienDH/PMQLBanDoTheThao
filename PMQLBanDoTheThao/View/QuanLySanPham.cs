using PMQLBanDoTheThao.Controller;
using PMQLBanDoTheThao.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PMQLBanDoTheThao.View
{
    public partial class QuanLySanPham : UserControl
    {
        private readonly QuanLySanPhamController _controller = new QuanLySanPhamController();
        private int _currentProductId = 0;
        private int _currentVariantId = 0;
        public QuanLySanPham()
        {
            InitializeComponent();
            LoadComboBoxes();
            LoadDataGrid();
            dgvSanPham.CellClick += dgvSanPham_CellClick;
            dgvSanPham.CellFormatting += dgvSanPham_CellFormatting;
            dgvBienThe.CellClick += dgvBienThe_CellClick;
            //btnSuaBienThe.Click += btnSuaBienThe_Click;
            //btnXoaBienThe.Click += btnXoaBienThe_Click;
        }

        #region Load ComboBox

        private void LoadComboBoxes()
        {
            // 1. Load Danh mục (Bạn cần thêm hàm GetAllCategories() vào Controller nhé)
            cmbDanhMuc.DataSource = _controller.GetAllCategories();
            cmbDanhMuc.DisplayMember = "CategoryName";
            cmbDanhMuc.ValueMember = "Id";

            // 2. Load Size
            cmbSize.DataSource = _controller.GetAllSizes();
            cmbSize.DisplayMember = "Name";
            cmbSize.ValueMember = "Id";

            // 3. Load Màu sắc
            cmbMau.DataSource = _controller.GetAllColors();
            cmbMau.DisplayMember = "Name";
            cmbMau.ValueMember = "Id";
        }

        private void LoadDataGrid()
        {
            dgvSanPham.DataSource = _controller.GetAllProducts();
            FormatDataGrid();
        }

        private void FormatDataGrid()
        {
            if (dgvSanPham.Columns["Id"] != null) dgvSanPham.Columns["Id"].Visible = false;
            if (dgvSanPham.Columns["CategoryId"] != null) dgvSanPham.Columns["CategoryId"].Visible = false;
            if (dgvSanPham.Columns["ImagePath"] != null) dgvSanPham.Columns["ImagePath"].Visible = false;

            if (!dgvSanPham.Columns.Contains("ColImage"))
            {
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.Name = "ColImage";
                imgCol.HeaderText = "Ảnh sản phẩm";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.Width = 100;

                // ---> DÒNG QUAN TRỌNG: XÓA DẤU X ĐỎ NẾU KHÔNG CÓ ẢNH <---
                imgCol.DefaultCellStyle.NullValue = null;

                dgvSanPham.Columns.Insert(0, imgCol);
            }

            dgvSanPham.RowTemplate.Height = 80;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        #endregion

        #region Validation

        private bool ValidateProductInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenSanPham.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSanPham.Focus();
                return false;
            }

            if (cmbDanhMuc.SelectedValue == null || Convert.ToInt32(cmbDanhMuc.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDanhMuc.Focus();
                return false;
            }

            if (!decimal.TryParse(txtGiaBan.Text, out decimal gia) || gia <= 0)
            {
                MessageBox.Show("Giá bán phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateVariantInput()
        {
            if (cmbSize.SelectedValue == null || Convert.ToInt32(cmbSize.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn Size!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSize.Focus();
                return false;
            }

            if (cmbMau.SelectedValue == null || Convert.ToInt32(cmbMau.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn Màu sắc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMau.Focus();
                return false;
            }

            if (!int.TryParse(txtSoLuong.Text, out int sl) || sl < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên >= 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Button Events (Sản phẩm)

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateProductInput()) return;

            var sp = new Product
            {
                Name = txtTenSanPham.Text.Trim(),
                CategoryId = Convert.ToInt32(cmbDanhMuc.SelectedValue),
                Price = decimal.Parse(txtGiaBan.Text),
                ImagePath = txtHinhAnh.Text.Trim()
            };

            if (_controller.AddProduct(sp))
            {
                MessageBox.Show("Thêm sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearProductForm();
                LoadDataGrid();
            }
            else
                MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_currentProductId == 0)
            {
                MessageBox.Show("Chưa chọn sản phẩm để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateProductInput()) return;

            var sp = new Product
            {
                Id = _currentProductId,
                Name = txtTenSanPham.Text.Trim(),
                CategoryId = Convert.ToInt32(cmbDanhMuc.SelectedValue),
                Price = decimal.Parse(txtGiaBan.Text),
                ImagePath = txtHinhAnh.Text.Trim()
            };

            if (_controller.UpdateProduct(sp))
            {
                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearProductForm();
                LoadDataGrid();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_currentProductId == 0) return;

            if (MessageBox.Show("Xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_controller.DeleteProduct(_currentProductId))
                {
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearProductForm();
                    LoadDataGrid();
                }
            }
        }

        #endregion

        #region Variant Events

        private void btnThemBienThe_Click(object sender, EventArgs e)
        {
            if (_currentProductId == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước khi thêm biến thể!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateVariantInput()) return;

            int sizeId = Convert.ToInt32(cmbSize.SelectedValue);
            int colorId = Convert.ToInt32(cmbMau.SelectedValue);

            // 🔥 CHECK TRÙNG NGAY TRÊN GRID
            foreach (DataGridViewRow row in dgvBienThe.Rows)
            {
                if (row.Cells["SizeId"].Value != null && row.Cells["ColorId"].Value != null)
                {
                    int existingSize = Convert.ToInt32(row.Cells["SizeId"].Value);
                    int existingColor = Convert.ToInt32(row.Cells["ColorId"].Value);

                    if (existingSize == sizeId && existingColor == colorId)
                    {
                        MessageBox.Show("Biến thể (Size + Màu) này đã tồn tại!\nVui lòng sửa sản phẩm.",
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            var variant = new ProductVariant
            {
                ProductId = _currentProductId,
                SizeId = sizeId,
                ColorId = colorId,
                Quantity = int.Parse(txtSoLuong.Text)
            };

            if (_controller.AddProductVariant(variant))
            {
                MessageBox.Show("Thêm biến thể thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVariantsForCurrentProduct();
                txtSoLuong.Clear();
            }
        }

        private void LoadVariantsForCurrentProduct()
        {
            if (_currentProductId > 0)
            {
                dgvBienThe.DataSource = null;
                dgvBienThe.DataSource = _controller.GetVariantsByProductId(_currentProductId);
            }
            if (dgvBienThe.Columns["ProductId"] != null)
            {
                dgvBienThe.Columns["ProductId"].Visible = false;
            }

            // GỢI Ý THÊM: 
            // Nhìn ảnh bạn gửi, bạn có cả SizeId, SizeName, ColorId, ColorName.
            // Đã có Tên rồi thì bạn nên ẩn luôn cả ID của Size và Màu sắc đi cho bảng cực gọn:
            if (dgvBienThe.Columns["SizeId"] != null)
            {
                dgvBienThe.Columns["SizeId"].Visible = false;
            }

            if (dgvBienThe.Columns["ColorId"] != null)
            {
                dgvBienThe.Columns["ColorId"].Visible = false;
            }
        }

        #endregion

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _currentProductId = Convert.ToInt32(dgvSanPham.Rows[e.RowIndex].Cells["Id"].Value);

            txtTenSanPham.Text = dgvSanPham.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            cmbDanhMuc.SelectedValue = dgvSanPham.Rows[e.RowIndex].Cells["CategoryId"].Value;
            txtGiaBan.Text = dgvSanPham.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            txtHinhAnh.Text = dgvSanPham.Rows[e.RowIndex].Cells["ImagePath"].Value?.ToString() ?? "";

            LoadVariantsForCurrentProduct();
        }

        private void ClearProductForm()
        {
            _currentProductId = 0;
            txtTenSanPham.Clear();
            txtGiaBan.Clear();
            txtHinhAnh.Clear();
            cmbDanhMuc.SelectedIndex = -1;
            dgvBienThe.DataSource = null;
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtHinhAnh.Text = openFileDialog.FileName;
                }
            }
        }
        // Đảm bảo bạn có dòng này ở trên cùng file nhé:
        // using System.IO;

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra đúng cột ảnh và dòng hợp lệ
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "ColImage" && e.RowIndex >= 0)
            {
                Product product = (Product)dgvSanPham.Rows[e.RowIndex].DataBoundItem;

                if (product != null && !string.IsNullOrWhiteSpace(product.ImagePath))
                {
                    if (File.Exists(product.ImagePath))
                    {
                        try
                        {
                            // CÁCH MỚI CHUẨN 100%: Đọc file thành mảng byte, rồi mới nạp vào Image
                            byte[] imageBytes = System.IO.File.ReadAllBytes(product.ImagePath);
                            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                            {
                                e.Value = Image.FromStream(ms);
                            }
                        }
                        catch
                        {
                            e.Value = null;
                        }
                    }
                }
            }
        }

        // Sự kiện Click vào bảng Biến thể
        private void dgvBienThe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvBienThe.Rows[e.RowIndex];

            // Lấy ID của biến thể đang click
            _currentVariantId = Convert.ToInt32(row.Cells["Id"].Value);

            // Đổ dữ liệu ngược lên ComboBox và Textbox để nhìn
            cmbSize.SelectedValue = row.Cells["SizeId"].Value;
            cmbMau.SelectedValue = row.Cells["ColorId"].Value;
            txtSoLuong.Text = row.Cells["Quantity"].Value.ToString();
        }

        // Nút Sửa Số Lượng Biến Thể
        private void btnSuaBienThe_Click(object sender, EventArgs e)
        {
            if (_currentVariantId == 0)
            {
                MessageBox.Show("Vui lòng chọn biến thể cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int sl) || sl < 0)
            {
                MessageBox.Show("Số lượng phải >= 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            try
            {
                bool result = _controller.UpdateVariantQuantity(_currentVariantId, sl);

                if (result)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _currentVariantId = 0;
                    txtSoLuong.Clear();
                    cmbSize.SelectedIndex = -1;
                    cmbMau.SelectedIndex = -1;

                    LoadVariantsForCurrentProduct();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Nút Xóa Biến Thể
        private void btnXoaBienThe_Click(object sender, EventArgs e)
        {
            if (_currentVariantId == 0)
            {
                MessageBox.Show("Vui lòng chọn biến thể để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa biến thể này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_controller.DeleteVariant(_currentVariantId))
                {
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _currentVariantId = 0;
                    txtSoLuong.Clear();
                    cmbSize.SelectedIndex = -1;
                    cmbMau.SelectedIndex = -1;

                    LoadVariantsForCurrentProduct();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTenSanPham.Text.Trim();

            dgvSanPham.DataSource = _controller.SearchProducts(keyword);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Reset product
            _currentProductId = 0;
            txtTenSanPham.Clear();
            txtGiaBan.Clear();
            txtHinhAnh.Clear();
            cmbDanhMuc.SelectedIndex = -1;

            // Reset variant
            _currentVariantId = 0;
            txtSoLuong.Clear();
            cmbSize.SelectedIndex = -1;
            cmbMau.SelectedIndex = -1;

            // Clear bảng biến thể
            dgvBienThe.DataSource = null;

            // Load lại bảng sản phẩm
            LoadDataGrid();

            MessageBox.Show("Đã làm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
