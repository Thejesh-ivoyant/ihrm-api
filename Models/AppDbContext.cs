using IhrmApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace IhrmApi.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        // Ensure the DbContext is configured to use PostgreSQL
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Use Npgsql if not configured externally
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ihrm-db;Username=postgres;Password=*Veena2023");
            }
        }
    }
}