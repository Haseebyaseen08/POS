using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using POS.Data.Entities;
using POS.Data.Helper;
using System.Data;

namespace POS.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRoles, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");


            modelBuilder.Entity<ApplicationRoles>().ToTable("ApplicationRoles");
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationRoles> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
