using LiquarShopDataTask.Models;
using Microsoft.EntityFrameworkCore;
namespace LiquarShopDataTask.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
