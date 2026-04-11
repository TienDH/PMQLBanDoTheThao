using System;

namespace PMQLBanDoTheThao.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        // Các cột quyền mới (Tương ứng với các cột bit trong SQL)
        public bool CanManageProduct { get; set; }
        public bool CanManageInvoice { get; set; }
        public bool CanSeeStatistic { get; set; }
        public bool CanManageStaff { get; set; }
    }

    public static class UserSession
    {
        public static User CurrentUser { get; set; }
    }
}
