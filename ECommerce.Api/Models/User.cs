namespace ECommerce.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "User"; // Default role is "User"
        public DateTime CreatedAt { get; set; } = new DateTime(
                DateTime.UtcNow.Year,
                DateTime.UtcNow.Month,
                DateTime.UtcNow.Day,
                DateTime.UtcNow.Hour,
                DateTime.UtcNow.Minute,
                DateTime.UtcNow.Second,
                DateTimeKind.Utc
        );
    }
}

