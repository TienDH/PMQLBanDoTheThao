using PMQLBanDoTheThao.Controller;
using PMQLBanDoTheThao.Model;
using System;
using System.Windows.Forms;

namespace PMQLBanDoTheThao.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu và làm sạch khoảng trắng
            string user = txtUserName.Text.Trim();
            string pass = txtPassword.Text.Trim();

            // 2. Kiểm tra không được để trống
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Gọi Controller xử lý
            UserController ctrl = new UserController();

            if (ctrl.Login(user, pass))
            {
                // Đăng nhập thành công
                MessageBox.Show($"Chào mừng {UserSession.CurrentUser.Username} quay trở lại!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kiểm tra nếu Form này được mở từ MainMenu (dùng ShowDialog)
                if (this.Owner is MainMenu)
                {
                    this.DialogResult = DialogResult.OK; // Trả về kết quả để MainMenu biết đã login xong
                    this.Close();
                }
                else
                {
                    // Nếu Login là form khởi chạy đầu tiên của ứng dụng
                    this.Hide();
                    MainMenu main = new MainMenu();
                    main.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                // Đăng nhập thất bại (Sai user hoặc sai pass)
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Xác nhận trước khi thoát
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Hỗ trợ nhấn Enter để đăng nhập nhanh
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnLogIn.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}