using AdminCRUDTask.Models;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace AdminCRUDTask.DAL
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) :base(option){ }
        public DbSet<Slider> Sliders { get; set; }



    }
}
