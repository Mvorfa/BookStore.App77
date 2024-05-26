using CarStore.App.Models;
using Microsoft.EntityFrameworkCore;

namespace CarStore.App.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
             
    }
        public DbSet<Models.Car> Cars { get; set; }
        public DbSet <Models.Company> Companies { get; set;}

    }
}
