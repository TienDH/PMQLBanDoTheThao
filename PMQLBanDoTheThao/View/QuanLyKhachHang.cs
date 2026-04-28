using PMQLBanDoTheThao.Controller;
using PMQLBanDoTheThao.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PMQLBanDoTheThao.View
{
    // Đảm bảo class kế thừa UserControl và tên class đúng ý bạn
    public partial class QuanLyKhachHang : UserControl
    {
        private QuanLyKhachHangController controller = new QuanLyKhachHangController();
        private int selectedCustomerId = -1;

        public QuanLyKhachHang()
        {
            InitializeComponent();
            LoadData();
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var danhSach = controller.XuLyTimKiem("");
                dgvKhachHang.DataSource = danhSach;

                if (dgvKhachHang.Columns.Count > 0)
                {
                    if (dgvKhachHang.Columns["Id"] != null) dgvKhachHang.Columns["Id"].HeaderText = "Mã KH";
                    if (dgvKhachHang.Columns["Name"] != null) dgvKhachHang.Columns["Name"].HeaderText = "Tên Khách Hàng";
                    if (dgvKhachHang.Columns["Phone"] != null) dgvKhachHang.Columns["Phone"].HeaderText = "Số Điện Thoại";
                    if (dgvKhachHang.Columns["Address"] != null) dgvKhachHang.Columns["Address"].HeaderText = "Địa Chỉ";
                }
            }
            catch (Exception ex)
            {
                // Tránh lỗi khi Designer cố render dữ liệu
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Customer newCustomer = new Customer()
            {
                Name = txtHoTen.Text.Trim(),
                Phone = txtSdt.Text.Trim(),
                Address = txtEmail.Text.Trim()
            };

            string thongBao = controller.XuLyThemKhachHang(newCustomer);
            MessageBox.Show(thongBao, "Thông báo");
            LoadData();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                selectedCustomerId = Convert.ToInt32(row.Cells["Id"].Value);
                txtHoTen.Text = row.Cells["Name"].Value?.ToString();
                txtSdt.Text = row.Cells["Phone"].Value?.ToString();
                txtEmail.Text = row.Cells["Address"].Value?.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng!");
                return;
            }

            Customer cusUpdate = new Customer()
            {
                Id = selectedCustomerId,
                Name = txtHoTen.Text.Trim(),
                Phone = txtSdt.Text.Trim(),
                Address = txtEmail.Text.Trim()
            };

            string thongBao = controller.XuLySuaKhachHang(cusUpdate);
            MessageBox.Show(thongBao);
            if (thongBao.Contains("thành công")) LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1) return;

            if (MessageBox.Show("Xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (controller.XuLyXoaKhachHang(selectedCustomerId))
                {
                    LamMoiGiaoDien();
                    LoadData();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiGiaoDien();
            LoadData();
        }

        private void LamMoiGiaoDien()
        {
            txtHoTen.Clear();
            txtSdt.Clear();
            txtEmail.Clear();
            selectedCustomerId = -1;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = controller.XuLyTimKiem(txtTimKiem.Text.Trim());
        }
    }
}