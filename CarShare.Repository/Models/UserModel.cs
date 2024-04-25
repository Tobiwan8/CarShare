using System.ComponentModel;

namespace CarShare.Repository.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string? UserName { get; set; }
        [PasswordPropertyText]
        public string? Password { get; set; }
        public string? Role { get; set; } = "User";


    }
}
