using AutoMapper;
using FinTech.Data;
using FinTech.Models;
using FinTech.Models.DTOs;
using FinTech.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinTech.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;   

        public UserRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;   
        }
        public async Task AddAsync(UserDTO entity)
        {
            var user = _mapper.Map<User>(entity);
            await base.AddAsync(user);
        }

        public async Task<UserDTO?> GetByUserNameAsync(string userName)
        {
            var users = await base.GetAllAsync();
            var user = users.FirstOrDefault(x => x.UserName.Equals(userName));
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> RemoveAsync(UserDTO entity)
        {
            var user = _mapper.Map<User>(entity);
            return await base.RemoveAsync(user);
        }

        public async Task UpdateAsync(UserDTO entity)
        {
            var user = _mapper.Map<User>(entity);
            await base.UpdateAsync(user);
        }
    }



}

