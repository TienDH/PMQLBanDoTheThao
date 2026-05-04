using PMQLBanDoTheThao.Controller;
using PMQLBanDoTheThao.Model;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Bắt buộc phải có để vẽ Chart

namespace PMQLBanDoTheThao.View
{
    public partial class BaoCao : UserControl
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
                // Khởi tạo các biến thời gian
                DateTime tuNgay = dtpTuNgay.Value;
                DateTime denNgay = dtpDenNgay.Value;

                // Đảm bảo Controller đã được khởi tạo
                if (controller == null) controller = new BaoCaoController();

                // =============================================================
                // 1. XỬ LÝ DATAGRIDVIEW (CHI TIẾT ĐƠN HÀNG)
                // =============================================================
                List<OrderDetailReport> dsDonHang = controller.LayDanhSachDonHang(tuNgay, denNgay);

                // Luôn gán Datasource ngay cả khi list rỗng để làm sạch bảng cũ
                dgvBaoCao.DataSource = dsDonHang;

                if (dsDonHang != null && dsDonHang.Count > 0)
                {
                    // Tùy chỉnh hiển thị tiêu đề tiếng Việt
                    dgvBaoCao.Columns["OrderId"].HeaderText = "Mã Đơn";
                    dgvBaoCao.Columns["OrderDate"].HeaderText = "Ngày Lập";
                    dgvBaoCao.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvBaoCao.Columns["CustomerName"].HeaderText = "Khách Hàng";
                    dgvBaoCao.Columns["StaffName"].HeaderText = "Nhân Viên";

                    dgvBaoCao.Columns["TotalAmount"].HeaderText = "Tổng Tiền (VNĐ)";
                    dgvBaoCao.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                    dgvBaoCao.Columns["TotalAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    // Tính tổng doanh thu
                    decimal tongCong = dsDonHang.Sum(x => x.TotalAmount);
                    lblTongDoanhThu.Text = $"Tổng doanh thu: {tongCong:N0} VNĐ";
                }
                else
                {
                    lblTongDoanhThu.Text = "Tổng doanh thu: 0 VNĐ";
                }

                // =============================================================
                // 2. XỬ LÝ CHART (BIỂU ĐỒ TỔNG HỢP)
                // =============================================================
                List<DoanhThuReport> dsDoanhThu = controller.LayDoanhThu(tuNgay, denNgay);
                VeBieuDo(dsDoanhThu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Hàm tách riêng để xử lý vẽ biểu đồ
        /// </summary>
        private void VeBieuDo(List<DoanhThuReport> ds)
        {
            // Làm sạch biểu đồ cũ
            chartDoanhThu.Series.Clear();

            if (ds == null || ds.Count == 0) return;

            // Tạo Series mới
            Series series = new Series("DoanhThu")
            {
                ChartType = SeriesChartType.Column, // Dạng cột đứng
                XValueType = ChartValueType.Date,
                IsValueShownAsLabel = true,        // Hiện số tiền trên đầu cột
                LabelFormat = "N0",
                Color = System.Drawing.Color.DodgerBlue // Màu sắc cho chuyên nghiệp
            };

            // Đổ dữ liệu
            foreach (var item in ds)
            {
                series.Points.AddXY(item.Ngay, item.TongDoanhThu);
            }
            chartDoanhThu.Series.Add(series);

            // Cấu hình trục và thanh cuộn (Scrollbar)
            ChartArea chartArea = chartDoanhThu.ChartAreas[0];
            chartArea.AxisX.LabelStyle.Format = "dd/MM";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.Title = "Ngày giao dịch";
            chartArea.AxisY.Title = "Doanh thu (VNĐ)";

            // Xử lý dữ liệu lớn: Nếu > 10 ngày thì cho phép cuộn
            if (ds.Count > 10)
            {
                chartArea.AxisX.ScrollBar.Enabled = true;
                chartArea.AxisX.ScaleView.Zoomable = true;
                chartArea.AxisX.ScaleView.Size = 10; // Chỉ hiển thị 10 cột một lúc
            }
            else
            {
                chartArea.AxisX.ScrollBar.Enabled = false;
                chartArea.AxisX.ScaleView.ZoomReset();
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvBaoCao.Rows.Count == 0 || dgvBaoCao.DataSource == null)
            {
                MessageBox.Show("Không có dữ liệu để xuất! Vui lòng bấm Thống kê trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;

                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                worksheet.Name = "Báo cáo chi tiết";

                // Viết tiêu đề cột
                for (int i = 1; i < dgvBaoCao.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgvBaoCao.Columns[i - 1].HeaderText;
                    worksheet.Cells[1, i].Font.Bold = true;
                }

                // Viết dữ liệu (Chỉ xuất các cột hiển thị được)
                for (int i = 0; i < dgvBaoCao.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvBaoCao.Columns.Count; j++)
                    {
                        var cellValue = dgvBaoCao.Rows[i].Cells[j].Value;
                        if (cellValue != null)
                        {
                            // Định dạng cột ngày tháng cho Excel
                            if (dgvBaoCao.Columns[j].Name == "OrderDate")
                            {
                                worksheet.Cells[i + 2, j + 1] = Convert.ToDateTime(cellValue).ToString("dd/MM/yyyy HH:mm");
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = cellValue.ToString();
                            }
                        }
                    }
                }

                // Tổng cộng
                int lastRow = dgvBaoCao.Rows.Count + 3;
                worksheet.Cells[lastRow, 1] = "TỔNG CỘNG:";
                worksheet.Cells[lastRow, 1].Font.Bold = true;
                worksheet.Cells[lastRow, 2] = lblTongDoanhThu.Text.Replace("Tổng doanh thu: ", "");
                worksheet.Cells[lastRow, 2].Font.Bold = true;
                worksheet.Cells[lastRow, 2].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                worksheet.Columns.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}