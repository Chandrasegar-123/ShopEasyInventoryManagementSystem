namespace ShopEasyIMS.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty; // Plain password input (for creating/updating)

        public string Role { get; set; } = "Employee"; // Default to "Employee"
    }
}
