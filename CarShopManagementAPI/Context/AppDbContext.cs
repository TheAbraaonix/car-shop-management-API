using CarShopManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShopManagementAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Car> Cars { get; set; }
    }
}
