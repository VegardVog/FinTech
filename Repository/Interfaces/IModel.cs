using System.ComponentModel.DataAnnotations;

namespace FinTech.Repository.Interfaces
{
    public interface IModel
    {
        [Key]
        int Id { get; }
    }
}
