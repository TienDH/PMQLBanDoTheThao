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
            var res = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;

            // 2. Xóa dữ liệu người dùng hiện tại
            UserSession.CurrentUser = null;
            panelMain.Controls.Clear();

            // 3. ẨN CÁI KHUNG ĐẰNG SAU (MainMenu)
            this.Hide();

            // 4. Mở form Login
            using (var loginForm = new Login())
            {
                // ShowDialog sẽ dừng chương trình tại đây cho đến khi form Login đóng
                loginForm.ShowDialog();
            }

            // 5. Sau khi Login đóng, kiểm tra xem có ai đăng nhập mới không
            if (UserSession.CurrentUser != null)
            {
                // Nếu đăng nhập thành công -> Cập nhật nút và HIỆN LẠI MainMenu
                UpdateAuthButtons();
                this.Show();
            }
            else
            {
                // Nếu họ bấm "Exit" ở form Login hoặc đóng mà không đăng nhập -> Thoát hẳn app
                Application.Exit();
            }
        }

        // Áp phân quyền: ẩn/hiện các control có Tag="AdminOnly" nếu không phải Admin
        public void ApplyRolePermissions()
        {
            var user = UserSession.CurrentUser;
            if (user == null) return;

            // 1. Xác định Role (giả sử Staff của bạn trong DB tên là "Staff")
            bool isAdmin = string.Equals(user.Role, "Admin", StringComparison.OrdinalIgnoreCase);
            bool isStaff = string.Equals(user.Role, "Staff", StringComparison.OrdinalIgnoreCase);

            // 2. Phân quyền ẩn/hiện các nút menu như cũ
            btnQuanLySanPham.Visible = isAdmin;
            btnQuanLyKhachHang.Visible = isAdmin;
            BtnQuanLyKho.Visible = isAdmin;
            btnQuanLyNhanVien.Visible = isAdmin;
            btnThongKeBaoCao.Visible = isAdmin;

            // Nút hóa đơn thì cả Admin và Staff đều thấy
            btnQuanLyHoaDon.Visible = isAdmin || isStaff;

            // 3. TỰ ĐỘNG HIỆN QUẢN LÝ HÓA ĐƠN KHI LÀ STAFF
            if (isStaff)
            {
                MessageBox.Show("Tính năng Quản lý khách hàng đang được phát triển!", "Thông báo");
                //Nếu có r thì xóa ghi chú dòng bên dưới và bỏ messagebox đi
                //LoadControl(new QuanLyHoaDon());
            }
            else if (isAdmin)
            {
                panelMain.Controls.Clear();

                //Nếu có r thì xóa ghi chú dòng bên dưới và bỏ messagebox đi
                //LoadControl(new ThongKeBaoCao());
            }
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
            var res = MessageBox.Show("Bạn có muốn đăng xuất và quay lại màn hình đăng nhập?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                // 1. Xóa session người dùng
                UserSession.CurrentUser = null;
                panelMain.Controls.Clear();

                // 2. Ẩn form MainMenu hiện tại đi
                this.Hide();

                // 3. Mở lại form Login
                using (var loginForm = new Login())
                {
                    // Nếu login thành công, DialogResult nên là OK (bạn cần set trong form Login)
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // Cập nhật lại giao diện theo user mới
                        UpdateAuthButtons();
                        this.Show(); // Hiện lại MainMenu
                    }
                    else
                    {
                        // Nếu họ đóng form Login mà không đăng nhập -> Thoát app
                        Application.Exit();
                    }
                }
            }
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

        
    }
}
