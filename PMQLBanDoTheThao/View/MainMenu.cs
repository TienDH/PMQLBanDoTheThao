using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PMQLBanDoTheThao.View;
using PMQLBanDoTheThao.Model;

namespace PMQLBanDoTheThao
{
    public partial class MainMenu : Form
    {
        // Logout button được tạo động (không sửa Designer)
        private Button btnDangXuat;

        public MainMenu()
        {
            InitializeComponent();
            InitializeDynamicControls();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            UpdateAuthButtons();
        }

        private void InitializeDynamicControls()
        {
            // Tạo btnDangXuat nhưng không hiển thị ngay
            btnDangXuat = new Button
            {
                Anchor = (AnchorStyles.Top | AnchorStyles.Right),
                Font = btnDangNhap.Font,
                Size = btnDangNhap.Size,
                Location = btnDangNhap.Location, // đặt cùng vị trí với btnDangNhap
                Text = "Đăng xuất",
                Visible = false
            };
            btnDangXuat.Click += BtnDangXuat_Click;

            // Thêm vào panel2 (panel chứa các nút trên cùng)
            panelTop.Controls.Add(btnDangXuat);
            btnDangXuat.BringToFront();
        }

        private void UpdateAuthButtons()
        {
            bool loggedIn = UserSession.CurrentUser != null;

            // Ẩn/hiện các nút login/register/logout
            btnDangNhap.Visible = !loggedIn;
            btnDangXuat.Visible = loggedIn;

            // Cập nhật title
            if (loggedIn)
            {
                this.Text = $"PMQL - Người dùng: {UserSession.CurrentUser.Username} ({UserSession.CurrentUser.Role})";
            }
            else
            {
                this.Text = "PMQL";
            }

            // Áp quyền hiển thị control theo role
            string role = loggedIn ? (UserSession.CurrentUser.Role ?? string.Empty) : string.Empty;
            ApplyRolePermissions(role);
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            // Mở form login modal và truyền owner là MainMenu (this)
            using (var loginForm = new Login())
            {
                loginForm.ShowDialog(this);
            }

            // Sau khi form login đóng, cập nhật trạng thái hiển thị nút
            UpdateAuthButtons();
        }

        // Áp phân quyền: ẩn/hiện các control có Tag="AdminOnly" nếu không phải Admin
        private void ApplyRolePermissions(string role)
        {
            bool isAdmin = !string.IsNullOrWhiteSpace(role) && role.Equals("Admin", StringComparison.OrdinalIgnoreCase);

            // Duyệt đệ quy mọi control trong form
            SetAdminOnlyVisibilityRecursively(this.Controls, isAdmin);
        }

        private void SetAdminOnlyVisibilityRecursively(Control.ControlCollection controls, bool visibleForAdmin)
        {
            foreach (Control ctl in controls)
            {
                if (ctl.Tag != null && ctl.Tag.ToString().Contains("AdminOnly"))
                {
                    // Chỉ hiện nếu là Admin thực sự
                    ctl.Visible = visibleForAdmin;
                }

                if (ctl.HasChildren)
                {
                    SetAdminOnlyVisibilityRecursively(ctl.Controls, visibleForAdmin);
                }
            }
        }

        // Sự kiện bấm nút Đăng xuất (tạo động)
        private void BtnDangXuat_Click(object sender, EventArgs e)
        {
            // Xác nhận logout
            var res = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;

            // Xóa session
            UserSession.CurrentUser = null;

            // Cập nhật UI (ẩn các control AdminOnly)
            UpdateAuthButtons();

            // Mở lại login modal để người dùng có thể đăng nhập lại
            using (var loginForm = new Login())
            {
                loginForm.ShowDialog(this);
            }

            // Cập nhật UI lần nữa sau khi login lại
            UpdateAuthButtons();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadControl(UserControl uc)
        {
            panelMain.Controls.Clear();

            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }
        private void btnQuanLySanPham_Click(object sender, EventArgs e)
        {
            LoadControl(new QuanLySanPham());
        }


    }
}
