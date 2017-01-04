using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DemoApplication1.Models;
using DemoApplication1.Entities;

namespace DemoApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
     {
          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
          {
          }
          public DbSet<Employee> Employees { get; set; }
          public DbSet<City> Cities { get; set; }

          public DbSet<PointsOfInterest> PointsOfInterests { get; set; }
          protected override void OnModelCreating(ModelBuilder builder)
          {
               base.OnModelCreating(builder);
               // Customize the ASP.NET Identity model and override the defaults if needed.
               // For example, you can rename the ASP.NET Identity table names and more.
               // Add your customizations after calling base.OnModelCreating(builder);
          }
     }
}
