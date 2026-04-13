using PMQLBanDoTheThao.DataBase;
using PMQLBanDoTheThao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQLBanDoTheThao.Controller
{
    public class BaoCaoController
    {
        private BaoCaoDB db = new BaoCaoDB();

        public List<DoanhThuReport> LayDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            // Có thể thêm các logic kiểm tra ngày (Ví dụ: Từ ngày không được lớn hơn Đến ngày)
            if (tuNgay > denNgay)
            {
                throw new Exception("Ngày bắt đầu không được lớn hơn ngày kết thúc!");
            }

            return db.GetDoanhThuTheoKhoangThoiGian(tuNgay, denNgay);
        }
    }
}
