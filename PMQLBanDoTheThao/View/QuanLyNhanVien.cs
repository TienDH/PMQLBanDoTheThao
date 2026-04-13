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

                // Nếu lấy cả Password về nhưng không muốn hiện dãy mã hóa lên bảng
                if (dgvNhanVien.Columns.Contains("Password"))
                {
                    dgvNhanVien.Columns["Password"].Visible = false;
                }

                dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["Username"].Value.ToString().Trim();

                // Đổ mật khẩu mã hóa vào ô TextBox nếu cần
                if (dgvNhanVien.Columns.Contains("Password") && row.Cells["Password"].Value != null)
                {
                    txtPassword.Text = row.Cells["Password"].Value.ToString();
                }

                cboRole.Text = row.Cells["Role"].Value.ToString().Trim();
                txtUsername.Enabled = false; // Không cho sửa Username
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên và mật khẩu!");
                return;
            }

            // Gọi hàm AddUser mới (Chỉ còn 3 tham số)
            bool success = nvController.AddUser(
                txtUsername.Text.Trim(),
                txtPassword.Text,
                cboRole.Text
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

            // Gọi hàm UpdateUser mới (Chỉ còn 2 tham số: id và role)
            bool success = nvController.UpdateUser(id, cboRole.Text);

            if (success)
            {
                MessageBox.Show("Cập nhật chức vụ thành công!");
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

            // Đã xóa phần Clear CheckBox vì không còn dùng tới
            LoadData();
        }
    }
}