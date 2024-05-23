using FinTech.Models;
using FinTech.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FinTech.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

    }
}
