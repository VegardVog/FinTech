namespace FinTech.Models
{
    public class User
    {
        public required int Id { get; set; }
        public required string UserName { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
