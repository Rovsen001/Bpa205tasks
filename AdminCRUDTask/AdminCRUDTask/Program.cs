using AdminCRUDTask.DAL;
using Microsoft.EntityFrameworkCore;

namespace AdminCRUDTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(option => {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            var app = builder.Build();
            app.MapControllerRoute(
             name: "areas",
             pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{Id?}"
             );

            app.MapControllerRoute(
                name: "deafult",
                pattern: "{controller=Home}/{action=Index}/{Id?}"
                );
            app.UseStaticFiles();
            app.Run();
        }
    }
}
