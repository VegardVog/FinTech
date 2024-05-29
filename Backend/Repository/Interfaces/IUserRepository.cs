using FinTech.Models;
using FinTech.Models.DTOs;

namespace FinTech.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task AddAsync(UserDTO entity);
        Task<UserDTO?> GetByUserNameAsync(string userName);
        Task<bool> RemoveAsync(UserDTO entity);
        Task UpdateAsync(UserDTO entity);
    }
}
