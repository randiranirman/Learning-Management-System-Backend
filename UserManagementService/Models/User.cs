namespace UserManagementService.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email {  get; set; }= string.Empty;
        public string Username { get; set; }= string.Empty;
        public string hashedPassword { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? RefreshToken {  get; set; } 
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
