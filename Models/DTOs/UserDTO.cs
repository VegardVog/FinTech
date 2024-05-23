namespace FinTech.Models.DTOs
{
    public class UserDTO
    {
        public required string UserName { get; set; }

        public required string Email { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;

    }
}
