using System;

namespace PMQLBanDoTheThao.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }

    public static class UserSession
    {
        public static User CurrentUser { get; set; }
    }
}
