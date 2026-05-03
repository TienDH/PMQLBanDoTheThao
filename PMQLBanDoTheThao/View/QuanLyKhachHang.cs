using PMQLBanDoTheThao.Controller;
using PMQLBanDoTheThao.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PMQLBanDoTheThao.View
{
    public partial class QuanLyKhachHang : UserControl
    {
        private QuanLyKhachHangController controller = new QuanLyKhachHangController();
        private int selectedCustomerId = -1;

        public QuanLyKhachHang()
        {
            InitializeComponent();
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
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
                    if (dgvKhachHang.Columns["Email"] != null) dgvKhachHang.Columns["Email"].HeaderText = "Email";
                }

                dgvKhachHang.ClearSelection();
            }
            catch (Exception) { }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                selectedCustomerId = Convert.ToInt32(row.Cells["Id"].Value);

                txtHoTen.Text = row.Cells["Name"].Value?.ToString();
                txtSdt.Text = row.Cells["Phone"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();

                // Đảm bảo bạn đã đổi tên ô nhập địa chỉ thành txtDiaChi trên giao diện Design
                txtDiaChi.Text = row.Cells["Address"].Value?.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string phone = txtSdt.Text.Trim();

            if (string.IsNullOrEmpty(phone) || !phone.StartsWith("0") || phone.Length < 10 || phone.Length > 11 || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập 10-11 chữ số và bắt đầu bằng số 0.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại, không thực hiện thêm vào DB
            }

            Customer newCustomer = new Customer()
            {
                Name = txtHoTen.Text.Trim(),
                Phone = phone,
                Email = txtEmail.Text.Trim(),
                Address = txtDiaChi.Text.Trim() // Nhớ dùng đúng tên TextBox địa chỉ của bạn
            };

            string thongBao = controller.XuLyThemKhachHang(newCustomer);
            MessageBox.Show(thongBao, "Thông báo");
            LamMoiGiaoDien();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã chọn khách hàng nào chưa
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Vui lòng click chọn một khách hàng ở bảng dưới trước khi sửa!", "Hướng dẫn");
                return;
            }

            string phone = txtSdt.Text.Trim();

            // 2. Kiểm tra tính hợp lệ của Số điện thoại
            // Yêu cầu: Không được rỗng, bắt đầu bằng "0", độ dài từ 10-11 ký tự, và chỉ chứa các chữ số
            if (string.IsNullOrEmpty(phone) || !phone.StartsWith("0") || phone.Length < 10 || phone.Length > 11 || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập 10-11 chữ số và bắt đầu bằng số 0.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại, không thực hiện lệnh sửa bên dưới nữa
            }

            // 3. Tiến hành gán dữ liệu vào đối tượng
            Customer cusUpdate = new Customer()
            {
                Id = selectedCustomerId,
                Name = txtHoTen.Text.Trim(),
                Phone = phone, // Sử dụng biến phone đã được kiểm tra ở trên
                Email = txtEmail.Text.Trim(),
                Address = txtDiaChi.Text.Trim()
            };

            // 4. Gọi controller xử lý và hiển thị thông báo
            string thongBao = controller.XuLySuaKhachHang(cusUpdate);
            MessageBox.Show(thongBao, "Thông báo");

            // 5. Làm mới lại Form nếu sửa thành công
            if (thongBao.Contains("thành công"))
            {
                LamMoiGiaoDien();
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Vui lòng click chuột vào một dòng khách hàng ở bảng bên dưới trước khi bấm Xóa!", "Hướng dẫn");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (controller.XuLyXoaKhachHang(selectedCustomerId))
                {
                    MessageBox.Show("Đã xóa khách hàng thành công!");
                    LamMoiGiaoDien();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không thể xóa! Khách hàng này đã có Hóa đơn trong hệ thống.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtDiaChi.Clear();

            // Xóa luôn text ô tìm kiếm nếu bạn có đặt tên nó là txtTimKiem
            if (txtTimKiem != null) txtTimKiem.Clear();

            selectedCustomerId = -1;
            dgvKhachHang.ClearSelection();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = controller.XuLyTimKiem(txtTimKiem.Text.Trim());
        }
    }
}