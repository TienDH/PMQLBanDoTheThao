using PMQLBanDoTheThao.Controller;
using PMQLBanDoTheThao.DataBase;
using PMQLBanDoTheThao.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PMQLBanDoTheThao.View
{
    public partial class QuanLyKhachHang : Form
    {
        private QuanLyKhachHangController controller = new QuanLyKhachHangController();

        // Biến lưu Id khách hàng đang chọn (Mặc định -1 là chưa chọn ai)
        private int selectedCustomerId = -1;

        public QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            CustomerDB db = new CustomerDB();
            dgvKhachHang.DataSource = db.GetAll();

            // Đặt tên cột cho DataGridView
            dgvKhachHang.Columns["Id"].HeaderText = "Mã KH";
            dgvKhachHang.Columns["Name"].HeaderText = "Tên Khách Hàng";
            dgvKhachHang.Columns["Phone"].HeaderText = "Số Điện Thoại";
            dgvKhachHang.Columns["Address"].HeaderText = "Địa Chỉ";
        }

        // Sự kiện khi bấm nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            Customer newCustomer = new Customer()
            {
                Name = txtHoTen.Text,
                Phone = txtSdt.Text,
                Address = txtEmail.Text
            };

            string thongBao = controller.XuLyThemKhachHang(newCustomer);
            MessageBox.Show(thongBao);
            LoadData(); // Load lại bảng sau khi thêm
        }

        // Sự kiện khi bấm vào 1 dòng trong bảng
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

                selectedCustomerId = Convert.ToInt32(row.Cells["Id"].Value);

                txtHoTen.Text = row.Cells["Name"].Value.ToString();
                txtSdt.Text = row.Cells["Phone"].Value.ToString();
                txtEmail.Text = row.Cells["Address"].Value.ToString();
            }
        }

        // Sự kiện nút Sửa (Gọi qua Controller)
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng từ danh sách để sửa!");
                return;
            }

            Customer cusUpdate = new Customer()
            {
                Id = selectedCustomerId,
                Name = txtHoTen.Text,
                Phone = txtSdt.Text,
                Address = txtEmail.Text
            };

            // Chuyển việc gọi DataBase sang cho Controller xử lý
            string thongBao = controller.XuLySuaKhachHang(cusUpdate);
            MessageBox.Show(thongBao);

            // Nếu thành công thì mới tải lại dữ liệu bảng
            if (thongBao == "Cập nhật thành công!")
            {
                LoadData();
            }
        }

        // Sự kiện nút Xóa (Gọi qua Controller)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng từ danh sách để xóa!");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Chuyển việc gọi DataBase sang cho Controller xử lý
                if (controller.XuLyXoaKhachHang(selectedCustomerId))
                {
                    MessageBox.Show("Xóa thành công!");
                    selectedCustomerId = -1; // Reset lại trạng thái

                    // Xóa trắng các ô TextBox
                    txtHoTen.Clear();
                    txtSdt.Clear();
                    txtEmail.Clear();

                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Xóa trắng các ô nhập
            txtHoTen.Clear();
            txtSdt.Clear();
            txtEmail.Clear(); // Dù tên là txtEmail nhưng bạn đang dùng cho Address

            // Reset lại biến chọn khách hàng
            selectedCustomerId = -1;

            // Tải lại danh sách từ đầu
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text;
            dgvKhachHang.DataSource = controller.XuLyTimKiem(tuKhoa);
        }
    } // Kết thúc đúng class ở đây
}