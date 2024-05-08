using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace CarShare.Repository.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class UserModel
    {
        public int ID { get; set; }
        public string? UserName { get; set; }
        [PasswordPropertyText]
        public string? Password { get; set; }
        public string? Role { get; set; } = "User";
    }
}
