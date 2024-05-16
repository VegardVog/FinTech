namespace FinTech.Models
{
    public class User
    {
        public required int id { get; set; }
        public required string userName { get; set; }

        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;

    }
}
