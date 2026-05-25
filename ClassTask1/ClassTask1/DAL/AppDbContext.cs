using ClassTask1.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassTask1.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }
        public DbSet<Slider> Sliders { get; set; }

    }
}
