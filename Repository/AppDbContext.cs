
using AuthDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace AuthDemo.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}

