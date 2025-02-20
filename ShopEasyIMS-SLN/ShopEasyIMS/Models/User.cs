using System.ComponentModel.DataAnnotations;

namespace ShopEasyIMS.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string PasswordHash { get; set; } = string.Empty; // Store hashed password

        [Required]
        public string Role { get; set; } = "Employee"; // Either "Admin" or "Employee"
    }
}
