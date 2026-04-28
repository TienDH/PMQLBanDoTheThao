using PMQLBanDoTheThao.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQLBanDoTheThao
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
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
        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            

        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void BtnQuanLyKho_Click(object sender, EventArgs e)
        {

        }

        private void btnThongKeBaoCao_Click(object sender, EventArgs e)
        {
            // 1. Xóa giao diện cũ đang hiển thị trong vùng chính
            panelMain.Controls.Clear();

            // 2. Khởi tạo UserControl Báo Cáo (Không phải Form nữa nên không dùng TopLevel)
            View.BaoCao ucBaoCao = new View.BaoCao();

            // 3. Thiết lập thuộc tính để nhúng vào Panel
            ucBaoCao.Dock = DockStyle.Fill; // Tự động phóng to cho vừa khít panelMain

            // 4. Thêm vào Panel và hiển thị
            panelMain.Controls.Add(ucBaoCao);

            // Lưu ý: UserControl không cần gọi .Show(), nó sẽ tự hiển thị khi được Add vào Controls
        }
    }
}
