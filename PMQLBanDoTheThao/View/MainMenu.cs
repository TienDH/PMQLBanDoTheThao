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
            ApplyRolePermissions();
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
        public void ApplyRolePermissions()
        {

            var user = UserSession.CurrentUser;

            // Cho tất cả các nút hiện lên và sáng lên để có thể click được
            btnQuanLyHoaDon.Visible = true;
            btnQuanLyHoaDon.Enabled = true;

            btnQuanLySanPham.Visible = true;
            btnQuanLySanPham.Enabled = true;

            btnQuanLyKhachHang.Visible = true;
            btnQuanLyKhachHang.Enabled = true;

            BtnQuanLyKho.Enabled = true;
            BtnQuanLyKho.Visible = true;
           
            btnQuanLyNhanVien.Visible = true;
            btnQuanLyNhanVien.Enabled = true;

            btnThongKeBaoCao.Visible = true;
            btnThongKeBaoCao.Enabled = true;
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
            panelMain.Controls.Clear();
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

        //hàm check đăng nhập//
        private bool CheckPermission(string requiredRole = "")
        {
            if (UserSession.CurrentUser == null)
            {
                MessageBox.Show("Vui lòng đăng nhập để sử dụng chức năng này!", "Yêu cầu đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                using (var loginForm = new Login()) 
                {
                    loginForm.ShowDialog(this);
                }

                // Sau khi đóng Form Login, kiểm tra xem đã đăng nhập thành công chưa
                if (UserSession.CurrentUser == null) return false;
                UpdateAuthButtons();
            }

            // 2. Kiểm tra quyền Admin (nếu chức năng đó yêu cầu Admin)
            if (!string.IsNullOrEmpty(requiredRole) && !UserSession.CurrentUser.Role.Equals(requiredRole, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bạn không đủ quyền để truy cập vào chức năng này!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
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
        private void btnQuanLySanPham_Click_1(object sender, EventArgs e)
        {
            if (CheckPermission("Admin")) 
            {
                LoadControl(new QuanLySanPham());
            }
        }

        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            if (CheckPermission()) 
            {
                MessageBox.Show("Tính năng Quản lý khách hàng đang được phát triển!", "Thông báo");

                // LoadControl(new QuanLyKhachHang())//
            }
        }

        

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                //LoadControl(new QuanLyKhachHang());
                MessageBox.Show("Tính năng Quản lý khách hàng đang được phát triển!", "Thông báo");
            }
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                //LoadControl(new QuanLyNhanVien());
                MessageBox.Show("Tính năng Quản lý nhân viên đang được phát triển!", "Thông báo");
            }
        }

        private void BtnQuanLyKho_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin"))
            {
                //LoadControl(new QuanLyKho());
                MessageBox.Show("Tính năng Quản lý kho đang được phát triển!", "Thông báo");
            }
        }

        private void btnThongKeBaoCao_Click(object sender, EventArgs e)
        {
            if (CheckPermission("Admin")) { 
                //LoadControl(new ThongKeBaoCao());
                MessageBox.Show("Tính năng Thống kê báo cáo đang được phát triển!", "Thông báo");
            }
        }

<<<<<<< HEAD
        
=======
        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            LoadControl(new QuanLyLoaiSanPham());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadControl(new QuanLyVoucher());
        }
>>>>>>> feature/ql-loai-sp
    }
}
