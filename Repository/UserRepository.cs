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

        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);
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

