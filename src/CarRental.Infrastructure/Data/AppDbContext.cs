using CarRental.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Data
{
    internal class AppDbContext : IdentityDbContext
    {
        //todo: set to Public
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


        public DbSet<City> Cities { get; set; }
        public DbSet<Car> Cars { get; set; }


        public DbSet<User> Users { get; set; }


        //public AppDbContext(DbContextOptionsBuilder<AppDbContext<TId>> options)
        //{
        //    options.UseSqlite($"Data Source={System.IO.Path.Join(
        //            Environment.GetFolderPath(
        //                Environment.SpecialFolder.LocalApplicationData), "WeatherForecast.db")}");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<City>().ToTable("City");
            //modelBuilder.Entity<Car>().ToTable("Car");            
            //modelBuilder.Entity<User>().ToTable("User");
        }

       
    }
}
