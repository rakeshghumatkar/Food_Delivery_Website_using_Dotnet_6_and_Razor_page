using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<CategoryModel> Categories {get; set;}
        public DbSet<FoodType> FoodTypes {get; set;}

        public DbSet<MenuItem> MenuItems {get; set;}

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);

        //     //Pre-insert data here
        //     modelBuilder.Entity<CategoryModel>().HasData(
        //         new CategoryModel { Id = 1, Name = "Category 1", DisplayOrder = 199 },
        //         new CategoryModel { Id = 2, Name = "Category 2", DisplayOrder = 299 },
        //         new CategoryModel { Id = 3, Name = "Category 3", DisplayOrder = 399 }
        //     );

        //     modelBuilder.Entity<FoodType>().HasData(
        //         new FoodType { Id = 1, Name = "FoodType 1" },
        //         new FoodType { Id = 2, Name = "FoodType 2" },
        //         new FoodType { Id = 3, Name = "FoodType 3"}
        //     );
        //     //SaveChanges();
        // }
        
    }
}