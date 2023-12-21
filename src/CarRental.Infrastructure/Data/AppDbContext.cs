using CarRental.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Data
{
    internal class AppDbContext<TId> : DbContext
    {
        //todo: set to Public
        public AppDbContext(DbContextOptions<AppDbContext<TId>> options) : base(options)
        { }

        public DbSet<Car<TId>> Cars { get; set; }

        public DbSet<City<TId>> Cities { get; set; }

        //public AppDbContext(DbContextOptionsBuilder<AppDbContext<TId>> options)
        //{
        //    options.UseSqlite($"Data Source={System.IO.Path.Join(
        //            Environment.GetFolderPath(
        //                Environment.SpecialFolder.LocalApplicationData), "WeatherForecast.db")}");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car<TId>>().ToTable("Car");
            modelBuilder.Entity<Car<TId>>().ToTable("City");
        }
    }
}
