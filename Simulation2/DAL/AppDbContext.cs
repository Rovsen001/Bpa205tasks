using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Simulation2.Models;

namespace Simulation2.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser> 
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }
        public DbSet<Crypto> Cryptos { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
