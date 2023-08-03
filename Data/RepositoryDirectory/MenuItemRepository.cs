using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data.IRepositoryDirectory;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Data.RepositoryDirectory
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext db;

        public MenuItemRepository(ApplicationDbContext _db):base(_db)
        {
             db=_db;
        }
        public void Update(MenuItem obj)
        {
            MenuItem menuItem = db.MenuItems.FirstOrDefault(x=>x.Id== obj.Id);
            menuItem.Name = obj.Name;
            menuItem.Description = obj.Description;
            menuItem.Price = obj.Price;
            menuItem.FoodTypeId = obj.FoodTypeId;
            menuItem.CategoryModelId = obj.CategoryModelId;
            if(menuItem.Image != null)
            {
                menuItem.Image = obj.Image;
            }

        }
    }
}