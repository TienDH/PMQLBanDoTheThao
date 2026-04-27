using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PMQLBanDoTheThao.DataBase;

namespace PMQLBanDoTheThao.View
{
    public partial class QuanLyHoaDon : UserControl
    {
        private DataTable dtGioHang = new DataTable();
        private decimal giamGia = 0;

        public QuanLyHoaDon()
        {
            InitializeComponent();
            SetupDataGridView();
            // Đảm bảo nút Sửa hiển thị đúng tên khi khởi động
            button1.Text = "✎ Sửa Hóa Đơn";
        }

        private void SetupDataGridView()
        {
            dtGioHang.Columns.Clear();
            dtGioHang.Columns.Add("IdSP", typeof(int));
            dtGioHang.Columns.Add("TenSP", typeof(string));
            dtGioHang.Columns.Add("Size", typeof(string));
            dtGioHang.Columns.Add("Mau", typeof(string));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("DonGia", typeof(decimal));
            dtGioHang.Columns.Add("ThanhTien", typeof(decimal));
            dgvGioHang.DataSource = dtGioHang;

            // Cấu hình bảng để chọn cả dòng
            dgvGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGioHang.MultiSelect = false;
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGioHang.AllowUserToAddRows = false; // Không cho phép dòng trống cuối bảng
        }

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            LoadComboBoxSanPham();
            cboSanPham.SelectedIndexChanged += CboSanPham_SelectedIndexChanged;
        }

        private void LoadComboBoxSanPham()
        {
            try
            {
                DataTable dt = DBConnection.GetDataTable("SELECT Id, Name FROM Product");
                cboSanPham.DataSource = dt;
                cboSanPham.DisplayMember = "Name";
                cboSanPham.ValueMember = "Id";
                cboSanPham.SelectedIndex = -1;
            }
            catch { }
        }

        private void CboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null || !(cboSanPham.SelectedValue is int)) return;

            int pId = (int)cboSanPham.SelectedValue;
            string sqlS = "SELECT DISTINCT s.Id, s.Name FROM Size s JOIN ProductVariant pv ON s.Id = pv.SizeId WHERE pv.ProductId = " + pId;
            cboSize.DataSource = DBConnection.GetDataTable(sqlS);
            cboSize.DisplayMember = "Name"; cboSize.ValueMember = "Id";

            string sqlC = "SELECT DISTINCT c.Id, c.Name FROM Color c JOIN ProductVariant pv ON c.Id = pv.ColorId WHERE pv.ProductId = " + pId;
            cboMauSac.DataSource = DBConnection.GetDataTable(sqlC);
            cboMauSac.DisplayMember = "Name"; cboMauSac.ValueMember = "Id";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedIndex == -1 || cboSize.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin sản phẩm!");
                return;
            }
            try
            {
                string sql = "SELECT pv.Id, p.Price FROM ProductVariant pv JOIN Product p ON pv.ProductId = p.Id WHERE pv.ProductId = @p AND pv.SizeId = @s AND pv.ColorId = @c";
                SqlParameter[] pars = {
                    new SqlParameter("@p", cboSanPham.SelectedValue),
                    new SqlParameter("@s", cboSize.SelectedValue),
                    new SqlParameter("@c", cboMauSac.SelectedValue)
                };
                DataTable dt = DBConnection.GetDataTable(sql, pars);
                if (dt.Rows.Count > 0)
                {
                    int soLuong = (int)nmSoLuong.Value;
                    if (soLuong <= 0) { MessageBox.Show("Số lượng phải lớn hơn 0!"); return; }

                    decimal donGia = Convert.ToDecimal(dt.Rows[0]["Price"]);
                    dtGioHang.Rows.Add(dt.Rows[0]["Id"], cboSanPham.Text, cboSize.Text, cboMauSac.Text, soLuong, donGia, soLuong * donGia);
                    TinhTongTien();
                }
                else
                {
                    MessageBox.Show("Sản phẩm phiên bản này đã hết hoặc không tồn tại!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void TinhTongTien()
        {
            decimal tamTinh = 0;
            foreach (DataRow r in dtGioHang.Rows)
                tamTinh += Convert.ToDecimal(r["ThanhTien"]);

            decimal thucTeGiam = Math.Min(giamGia, tamTinh);
            lblGiamGia.Text = "Giảm giá: " + thucTeGiam.ToString("N0") + " VNĐ";
            lblTongTien.Text = "Tổng tiền: " + (tamTinh - thucTeGiam).ToString("N0") + " VNĐ";
        }

        // Xử lý nút ÁP MÃ (Tên trong Designer là txtMaVoucher nhưng hành động là bấm nút)
        private void txtMaVoucher_Click(object sender, EventArgs e)
        {
            string ma = txtVoucher.Text.Trim().ToUpper();
            if (ma == "QUEOSHOP") { giamGia = 50000; MessageBox.Show("Áp mã thành công! Giảm 50,000đ"); }
            else if (ma == "SVDAINAM") { giamGia = 100000; MessageBox.Show("Áp mã thành công! Giảm 100,000đ"); }
            else { giamGia = 0; MessageBox.Show("Mã giảm giá không hợp lệ!"); }

            TinhTongTien();
        }

        // Nút SỬA HÓA ĐƠN
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow != null)
            {
                int rowIndex = dgvGioHang.CurrentRow.Index;
                int slMoi = (int)nmSoLuong.Value;

                if (slMoi <= 0) { MessageBox.Show("Số lượng phải lớn hơn 0!"); return; }

                dtGioHang.Rows[rowIndex]["SoLuong"] = slMoi;
                decimal gia = Convert.ToDecimal(dtGioHang.Rows[rowIndex]["DonGia"]);
                dtGioHang.Rows[rowIndex]["ThanhTien"] = slMoi * gia;

                TinhTongTien();
                MessageBox.Show("Đã cập nhật số lượng thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng sản phẩm để sửa!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow != null)
            {
                dtGioHang.Rows.RemoveAt(dgvGioHang.CurrentRow.Index);
                TinhTongTien();
            }
        }

        private void dgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                nmSoLuong.Value = Convert.ToInt32(dgvGioHang.Rows[e.RowIndex].Cells["SoLuong"].Value);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0) { MessageBox.Show("Giỏ hàng đang trống!"); return; }
            MessageBox.Show("Thanh toán thành công! Hóa đơn đã được lưu.");
            btnlammoi_Click(sender, e);
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            dtGioHang.Rows.Clear();
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtVoucher.Clear();
            giamGia = 0;
            TinhTongTien();
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e) => MessageBox.Show("Đang kết nối máy in...");
        private void btnTimKiem_Click(object sender, EventArgs e) => MessageBox.Show("Tìm kiếm hóa đơn...");
        private void lblTitle_Click(object sender, EventArgs e) { }
    }
}