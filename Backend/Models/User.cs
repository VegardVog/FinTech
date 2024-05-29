using FinTech.Repository.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FinTech.Models
{
    public class User : IModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]

        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
