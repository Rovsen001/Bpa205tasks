using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Simulation6.Models;

namespace Simulation6.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) :base(option) { }
        public DbSet<Member> Members { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
