using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=(local)\sqlexpress;
                                                    initial catalog=FairviewDB;
                                                    persist security info=True;user id=sa;password=dotnettricks");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, Name="Grocery", Description="Grocery" },
                new Category() { CategoryId = 2, Name = "Stationary", Description = "Stationary" },
                new Category() { CategoryId = 3, Name = "Hardware", Description = "Hardware" }
            );
        }

    }
}
