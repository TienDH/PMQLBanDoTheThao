using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PMQLBanDoTheThao.DataBase;
using PMQLBanDoTheThao.Controller;
using PMQLBanDoTheThao.Model;

namespace PMQLBanDoTheThao.View
{
    public partial class QuanLyHoaDon : UserControl
    {
        // Bảng tạm để lưu dữ liệu hiển thị trên DataGridView (Giỏ hàng)
        private DataTable dtGioHang = new DataTable();

        // Chuỗi kết nối đã được trỏ đúng vào Database QL_HoaDon_Module của bạn
        // LƯU Ý: Nếu máy bạn không dùng SQLEXPRESS01 thì xóa số 01 đi nhé.
        private string connectionString = @"Data Source=.\SQLEXPRESS01;Initial Catalog=QL_HoaDon_Module;Integrated Security=True";

        public QuanLyHoaDon()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        // 1. Cấu hình bảng giỏ hàng
        private void SetupDataGridView()
        {
            dtGioHang.Columns.Clear();
            dtGioHang.Columns.Add("IdSP", typeof(int));
            dtGioHang.Columns.Add("TenSP", typeof(string));
            dtGioHang.Columns.Add("Size", typeof(string));
            dtGioHang.Columns.Add("Mau", typeof(string));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("DonGia", typeof(decimal));
            dtGioHang.Columns.Add("ThanhTien", typeof(decimal));

            dgvGioHang.DataSource = dtGioHang;

            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGioHang.BackgroundColor = System.Drawing.Color.White;
            dgvGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGioHang.AllowUserToAddRows = false;
            dgvGioHang.RowHeadersVisible = false;
        }

        // 2. Sự kiện load Form
        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            LoadComboBoxSanPham();

            cboSanPham.SelectedIndexChanged -= CboSanPham_SelectedIndexChanged;
            cboSanPham.SelectedIndexChanged += CboSanPham_SelectedIndexChanged;
        }

        // 3. Load danh sách sản phẩm
        private void LoadComboBoxSanPham()
        {
            try
            {
                DataTable dt = DBConnection.GetDataTable("SELECT Id, Name FROM Product");
                cboSanPham.DataSource = dt;
                cboSanPham.DisplayMember = "Name";
                cboSanPham.ValueMember = "Id";
                cboSanPham.SelectedIndex = -1;
            }
            catch { }
        }

        // 4. Lọc Size và Màu tự động dựa vào Sản phẩm được chọn
        private void CboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null || cboSanPham.SelectedIndex == -1) return;

            if (int.TryParse(cboSanPham.SelectedValue.ToString(), out int productId))
            {
                try
                {
                    string sqlSize = @"SELECT DISTINCT s.Id, s.Name FROM Size s 
                                       JOIN ProductVariant pv ON s.Id = pv.SizeId 
                                       WHERE pv.ProductId = @id";
                    cboSize.DataSource = DBConnection.GetDataTable(sqlSize, new SqlParameter[] { new SqlParameter("@id", productId) });
                    cboSize.DisplayMember = "Name";
                    cboSize.ValueMember = "Id";
                    cboSize.SelectedIndex = -1;

                    string sqlMau = @"SELECT DISTINCT c.Id, c.Name FROM Color c 
                                      JOIN ProductVariant pv ON c.Id = pv.ColorId 
                                      WHERE pv.ProductId = @id";
                    cboMauSac.DataSource = DBConnection.GetDataTable(sqlMau, new SqlParameter[] { new SqlParameter("@id", productId) });
                    cboMauSac.DisplayMember = "Name";
                    cboMauSac.ValueMember = "Id";
                    cboMauSac.SelectedIndex = -1;
                }
                catch { }
            }
        }

        // 5. NÚT THÊM HÀNG - Lấy giá và check tồn kho
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedIndex == -1 || cboSize.SelectedIndex == -1 || cboMauSac.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Sản phẩm, Size và Màu sắc!", "Thông báo");
                return;
            }

            int sl = (int)nmSoLuong.Value;
            if (sl <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo");
                return;
            }

            try
            {
                int pId = Convert.ToInt32(cboSanPham.SelectedValue);
                int sId = Convert.ToInt32(cboSize.SelectedValue);
                int cId = Convert.ToInt32(cboMauSac.SelectedValue);

                string sql = @"SELECT pv.Id, p.Price, pv.Quantity 
                               FROM ProductVariant pv
                               JOIN Product p ON pv.ProductId = p.Id
                               WHERE pv.ProductId = @p AND pv.SizeId = @s AND pv.ColorId = @c";

                SqlParameter[] pars = {
                    new SqlParameter("@p", pId),
                    new SqlParameter("@s", sId),
                    new SqlParameter("@c", cId)
                };

                DataTable dt = DBConnection.GetDataTable(sql, pars);

                if (dt.Rows.Count > 0)
                {
                    int variantId = Convert.ToInt32(dt.Rows[0]["Id"]);
                    decimal gia = Convert.ToDecimal(dt.Rows[0]["Price"]);
                    int tonKho = Convert.ToInt32(dt.Rows[0]["Quantity"]);

                    bool daCoTrongGio = false;
                    foreach (DataRow row in dtGioHang.Rows)
                    {
                        if (Convert.ToInt32(row["IdSP"]) == variantId)
                        {
                            int slMoi = Convert.ToInt32(row["SoLuong"]) + sl;
                            if (slMoi > tonKho)
                            {
                                MessageBox.Show($"Kho chỉ còn {tonKho} sản phẩm này!", "Cảnh báo");
                                return;
                            }
                            row["SoLuong"] = slMoi;
                            row["ThanhTien"] = slMoi * gia;
                            daCoTrongGio = true;
                            break;
                        }
                    }

                    if (!daCoTrongGio)
                    {
                        if (sl > tonKho)
                        {
                            MessageBox.Show($"Kho chỉ còn {tonKho} sản phẩm này!", "Cảnh báo");
                            return;
                        }
                        dtGioHang.Rows.Add(variantId, cboSanPham.Text, cboSize.Text, cboMauSac.Text, sl, gia, sl * gia);
                    }

                    TinhTongTien();
                }
                else
                {
                    MessageBox.Show("Sản phẩm mẫu này hiện đang hết hàng hoặc chưa nhập kho!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm vào giỏ: " + ex.Message);
            }
        }

        // 6. Tính tổng tiền
        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (DataRow r in dtGioHang.Rows)
            {
                tong += Convert.ToDecimal(r["ThanhTien"]);
            }
            lblTongTien.Text = "Tổng tiền: " + tong.ToString("N0") + " VNĐ";
        }

        // 7. NÚT THANH TOÁN - Lưu vào bảng Orders và OrderDetail
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống, hãy thêm đồ vào giỏ trước khi thanh toán!", "Thông báo");
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thanh toán?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                decimal tongTien = 0;
                foreach (DataRow r in dtGioHang.Rows) tongTien += Convert.ToDecimal(r["ThanhTien"]);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 7.1. Lưu vào bảng Orders
                        string sqlHoaDon = "INSERT INTO Orders (UserId, OrderDate, TotalAmount) OUTPUT INSERTED.Id VALUES (@uid, @date, @total)";
                        SqlCommand cmdHoaDon = new SqlCommand(sqlHoaDon, conn, transaction);
                        
                        cmdHoaDon.Parameters.AddWithValue("@uid", 3);
                        cmdHoaDon.Parameters.AddWithValue("@date", DateTime.Now);
                        cmdHoaDon.Parameters.AddWithValue("@total", tongTien);

                        int newOrderId = (int)cmdHoaDon.ExecuteScalar();

                        // 7.2. Lưu chi tiết & trừ tồn kho
                        foreach (DataRow row in dtGioHang.Rows)
                        {
                            int variantId = Convert.ToInt32(row["IdSP"]);
                            int soLuong = Convert.ToInt32(row["SoLuong"]);
                            decimal donGia = Convert.ToDecimal(row["DonGia"]);

                            // Lưu vào bảng OrderDetail
                            string sqlChiTiet = "INSERT INTO OrderDetail (OrderId, ProductVariantId, Quantity, Price) VALUES (@oId, @pvId, @qty, @price)";
                            SqlCommand cmdChiTiet = new SqlCommand(sqlChiTiet, conn, transaction);
                            cmdChiTiet.Parameters.AddWithValue("@oId", newOrderId);
                            cmdChiTiet.Parameters.AddWithValue("@pvId", variantId);
                            cmdChiTiet.Parameters.AddWithValue("@qty", soLuong);
                            cmdChiTiet.Parameters.AddWithValue("@price", donGia);
                            cmdChiTiet.ExecuteNonQuery();

                            // Trừ Kho
                            string sqlTruKho = "UPDATE ProductVariant SET Quantity = Quantity - @qty WHERE Id = @pvId";
                            SqlCommand cmdTruKho = new SqlCommand(sqlTruKho, conn, transaction);
                            cmdTruKho.Parameters.AddWithValue("@qty", soLuong);
                            cmdTruKho.Parameters.AddWithValue("@pvId", variantId);
                            cmdTruKho.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show("Thanh toán thành công! Hóa đơn đã được lưu vào Database.", "Thành công");

                        dtGioHang.Rows.Clear();
                        TinhTongTien();
                        nmSoLuong.Value = 0;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi thanh toán (Đã hoàn tác): " + ex.Message);
                    }
                }
            }
        }
    }
}