using System;
using System.Data;
using System.Windows.Forms;
using PMQLBanDoTheThao.Controller;

namespace PMQLBanDoTheThao.View
{
    public partial class QuanLyNhanVien : UserControl
    {
        NhanVienController nvController = new NhanVienController();

        public QuanLyNhanVien()
        {
            InitializeComponent();
            LoadData();
        }

        private void QuanLyNhanVien_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = nvController.GetAllUsers();
            dgvNhanVien.DataSource = dt;

            if (dgvNhanVien.Columns.Count > 0)
            {
                dgvNhanVien.Columns["Id"].HeaderText = "Mã NV";
                dgvNhanVien.Columns["Username"].HeaderText = "Tên đăng nhập";
                dgvNhanVien.Columns["Role"].HeaderText = "Chức vụ";

                // Tự động giãn các cột cho đẹp
                dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                // 1. Đổ dữ liệu vào TextBox (Dùng .Trim() để tránh lỗi khoảng trắng)
                txtUsername.Text = row.Cells["Username"].Value.ToString().Trim();
                txtPassword.Text = ""; // Không hiện pass cũ vì bảo mật

                // 2. Đổ dữ liệu vào ComboBox Chức vụ
                // Dùng thuộc tính .Text sẽ tìm giá trị khớp trong Items của ComboBox
                string roleValue = row.Cells["Role"].Value.ToString().Trim();
                cboRole.Text = roleValue;

                // 3. Đổ dữ liệu vào các CheckBox quyền
                chkSanPham.Checked = row.Cells["CanManageProduct"].Value.ToString().ToLower() == "true" || row.Cells["CanManageProduct"].Value.ToString() == "1";
                chkHoaDon.Checked = row.Cells["CanManageInvoice"].Value.ToString().ToLower() == "true" || row.Cells["CanManageInvoice"].Value.ToString() == "1";
                chkNhanVien.Checked = row.Cells["CanManageStaff"].Value.ToString().ToLower() == "true" || row.Cells["CanManageStaff"].Value.ToString() == "1";
                chkThongKe.Checked = row.Cells["CanSeeStatistic"].Value.ToString().ToLower() == "true" || row.Cells["CanSeeStatistic"].Value.ToString() == "1";

                // Khóa ô Username khi sửa
                txtUsername.Enabled = false;
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên và mật khẩu!");
                return;
            }

            bool success = nvController.AddUser(
                txtUsername.Text.Trim(),
                txtPassword.Text,
                cboRole.Text,
                chkSanPham.Checked,
                chkHoaDon.Checked,
                chkNhanVien.Checked,
                chkThongKe.Checked
            );

            if (success)
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                btnLamMoi_Click_1(null, null);
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["Id"].Value);
            bool success = nvController.UpdateUser(
                id,
                cboRole.Text,
                chkSanPham.Checked,
                chkHoaDon.Checked,
                chkNhanVien.Checked,
                chkThongKe.Checked
            );

            if (success)
            {
                MessageBox.Show("Cập nhật quyền thành công!");
                LoadData();
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["Id"].Value);
            string user = dgvNhanVien.CurrentRow.Cells["Username"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {user}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (nvController.DeleteUser(id))
                {
                    MessageBox.Show("Đã xóa nhân viên!");
                    btnLamMoi_Click_1(null, null);
                }
                else
                {
                    MessageBox.Show("Không thể xóa tài khoản Admin hệ thống!");
                }
            }
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Enabled = true;

            if (cboRole.Items.Count > 0) cboRole.SelectedIndex = 0;

            chkSanPham.Checked = false;
            chkHoaDon.Checked = false;
            chkNhanVien.Checked = false;
            chkThongKe.Checked = false;

            LoadData();
        }
    }
}