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
            btnDangXuat = new Button
            {
                Anchor = (AnchorStyles.Top | AnchorStyles.Right),
                Font = btnDangNhap.Font,
                Size = btnDangNhap.Size,
                Location = btnDangNhap.Location,
                Text = "Đăng xuất",
                Visible = false
            };
            btnDangXuat.Click += BtnDangXuat_Click;

            panelTop.Controls.Add(btnDangXuat);
            btnDangXuat.BringToFront();
        }

        private void UpdateAuthButtons()
        {
            bool loggedIn = UserSession.CurrentUser != null;
            btnDangNhap.Visible = !loggedIn;
            btnDangXuat.Visible = loggedIn;

            if (loggedIn)
            {
                this.Text = $"PMQL - Người dùng: {UserSession.CurrentUser.Username} ({UserSession.CurrentUser.Role})";
            }
            else
            {
                this.Text = "PMQL";
            }
            ApplyRolePermissions();
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            using (var loginForm = new Login())
            {
                loginForm.ShowDialog(this);
            }
            UpdateAuthButtons();
        }

        public void ApplyRolePermissions()
        {
            btnQuanLyHoaDon.Enabled = true;
            btnQuanLySanPham.Enabled = true;
            btnQuanLyKhachHang.Enabled = true;
            BtnQuanLyKho.Enabled = true;
            btnQuanLyNhanVien.Enabled = true;
            btnThongKeBaoCao.Enabled = true;
            btnLoaiSP.Enabled = true;
            button1.Enabled = true;
        }

        private void BtnDangXuat_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;

            UserSession.CurrentUser = null;
            panelMain.Controls.Clear();
            UpdateAuthButtons();

            using (var loginForm = new Login())
            {
                loginForm.ShowDialog(this);
            }
            UpdateAuthButtons();
        }

        private bool CheckPermission(string requiredRole = "")
        {
            if (UserSession.CurrentUser == null)
            {
                MessageBox.Show("Vui lòng đăng nhập để sử dụng chức năng này!", "Yêu cầu đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                using (var loginForm = new Login())
                {
                    loginForm.ShowDialog(this);
                }
                if (UserSession.CurrentUser == null) return false;
                UpdateAuthButtons();
            }

            if (!string.IsNullOrEmpty(requiredRole) && !UserSession.CurrentUser.Role.Equals(requiredRole, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bạn không đủ quyền để truy cập vào chức năng này!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        private void LoadControl(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
            uc.BringToFront();
        }

        // --- CÁC SỰ KIỆN CLICK ĐÃ HỢP NHẤT ---

        private void btnQuanLySanPham_Click_1(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                LoadControl(new QuanLySanPham());
            }
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                LoadControl(new QuanLyNhanVien());
            }
        }

        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                LoadControl(new QuanLyLoaiSanPham());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                LoadControl(new QuanLyVoucher());
            }
        }

        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            if (CheckPermission())
            {
                // Sử dụng UserControl từ nhánh Hoa Đơn
                LoadControl(new QuanLyHoaDon());
            }
        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                // Hiện tại nhánh ql-khach-hang chưa merge nên tạm để thông báo
                MessageBox.Show("Tính năng Quản lý khách hàng đang được phát triển!", "Thông báo");
            }
        }

        private void BtnQuanLyKho_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                MessageBox.Show("Tính năng Quản lý kho đang được phát triển!", "Thông báo");
            }
        }

        private void btnThongKeBaoCao_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                // Tương tự cho nhánh báo cáo
                MessageBox.Show("Tính năng Thống kê báo cáo đang được phát triển!", "Thông báo");
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e) { }
    }
}