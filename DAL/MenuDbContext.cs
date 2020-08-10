using System;
using MenuTest.Models;
using Microsoft.EntityFrameworkCore;
namespace MenuTest.Dal
{
    public class MenuDbContext:DbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options)
            :base(options)
        {}
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MenuItem>()
                .HasOne(i => i.Parent)
                .WithMany(c => c.Children)
                .HasForeignKey(i => i.ParentId);
        }
    }
}