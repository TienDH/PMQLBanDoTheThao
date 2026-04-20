using PMQLBanDoTheThao.Controller;
using PMQLBanDoTheThao.Model;
using Excel = Microsoft.Office.Interop.Excel;
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
    public partial class BaoCao : Form
    {
        private BaoCaoController controller = new BaoCaoController();

        public BaoCao()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value;
                DateTime denNgay = dtpDenNgay.Value;

                // 1. Gọi Controller lấy dữ liệu
                List<DoanhThuReport> duLieu = controller.LayDoanhThu(tuNgay, denNgay);

                // 2. Đổ dữ liệu lên DataGridView
                dgvBaoCao.DataSource = duLieu;

                // Tùy chỉnh tên cột cho đẹp
                if (dgvBaoCao.Columns.Count > 0)
                {
                    dgvBaoCao.Columns["Ngay"].HeaderText = "Ngày Giao Dịch";
                    dgvBaoCao.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    dgvBaoCao.Columns["TongDoanhThu"].HeaderText = "Tổng Doanh Thu (VNĐ)";
                    dgvBaoCao.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0"; // Format tiền tệ có dấu phẩy
                    dgvBaoCao.Columns["TongDoanhThu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // 3. Tính tổng tất cả các ngày để in ra Label
                decimal tongCong = duLieu.Sum(x => x.TongDoanhThu);
                lblTongDoanhThu.Text = $"Tổng doanh thu: {tongCong:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem bảng có dữ liệu không, nếu trống thì báo lỗi không cho xuất
            if (dgvBaoCao.Rows.Count == 0 || dgvBaoCao.DataSource == null)
            {
                MessageBox.Show("Không có dữ liệu để xuất! Vui lòng bấm Thống kê trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 1. Khởi tạo phần mềm Excel ngầm
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true; // Mở Excel lên cho người dùng xem luôn

                // 2. Tạo một file Excel mới (Workbook) và chọn trang tính đầu tiên (Worksheet)
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                worksheet.Name = "Báo cáo doanh thu";

                // 3. Viết tiêu đề cột từ DataGridView sang Excel
                for (int i = 1; i < dgvBaoCao.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgvBaoCao.Columns[i - 1].HeaderText;
                    worksheet.Cells[1, i].Font.Bold = true; // In đậm tiêu đề
                }

                // 4. Viết từng dòng dữ liệu từ DataGridView sang Excel
                for (int i = 0; i < dgvBaoCao.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvBaoCao.Columns.Count; j++)
                    {
                        if (dgvBaoCao.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvBaoCao.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                // 5. Thêm dòng "Tổng doanh thu" xuống cuối cùng của bảng Excel
                int lastRow = dgvBaoCao.Rows.Count + 3; // Cách ra 1 dòng cho đẹp
                worksheet.Cells[lastRow, 1] = "TỔNG CỘNG:";
                worksheet.Cells[lastRow, 1].Font.Bold = true;
                worksheet.Cells[lastRow, 2] = lblTongDoanhThu.Text.Replace("Tổng doanh thu: ", ""); // Lấy số tiền từ Label
                worksheet.Cells[lastRow, 2].Font.Bold = true;
                worksheet.Cells[lastRow, 2].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                // 6. Căn chỉnh tự động độ rộng các cột cho vừa vặn chữ
                worksheet.Columns.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
