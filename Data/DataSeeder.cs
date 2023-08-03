using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Models;

namespace FoodDelivery.Data
{
    public static class DataSeeder
    {
         public static void SeedData(ApplicationDbContext dbContext)
        {
            if (!dbContext.Categories.Any())
            {
                dbContext.Categories.AddRange(
                    new CategoryModel { Name = "Product 1", DisplayOrder = 199 },
                    new CategoryModel { Name = "Product 2", DisplayOrder = 159 },
                    new CategoryModel { Name = "Product 3", DisplayOrder = 795 }
                );

                dbContext.SaveChanges();
            }

            if(!dbContext.FoodTypes.Any())
            {
                dbContext.FoodTypes.AddRange(
                new FoodType { Name = "FoodType 1" },
                new FoodType { Name = "FoodType 2" },
                new FoodType { Name = "FoodType 3"}
                );

                dbContext.SaveChanges();

            }
        }
    }
}