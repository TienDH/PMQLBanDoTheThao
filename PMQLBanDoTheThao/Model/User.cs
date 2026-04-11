using System;

namespace PMQLBanDoTheThao.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        // Password removed from public model to avoid keeping hashes in memory/session
        public string Role { get; set; }
    }

    // Lớp tĩnh để lưu Session (Trạng thái đăng nhập)
    public static class UserSession
    {
        public static User CurrentUser { get; set; }
    }
}

