using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data.IRepositoryDirectory;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Data.RepositoryDirectory
{
    public class CategoryRepository : Repository<CategoryModel>, ICategoryRepository
    {
        private readonly ApplicationDbContext db;

        public CategoryRepository(ApplicationDbContext _db):base(_db)
        {
             db=_db;
        }
        public void Update(CategoryModel obj)
        {
            CategoryModel entity = db.Categories.FirstOrDefault(x=>x.Id == obj.Id);
            entity.Name = obj.Name;
            entity.DisplayOrder = obj.DisplayOrder;
            db.Categories.Update(entity);
        }
    }
}