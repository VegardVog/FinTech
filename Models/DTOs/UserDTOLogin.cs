namespace FinTech.Models.DTOs
{
    public class UserDTOLogin
    {
        public required string UserName { get; set; }
        public required string Password { get; set; } = string.Empty;

    }
}
