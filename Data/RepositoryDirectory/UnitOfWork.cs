using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data.IRepositoryDirectory;

namespace FoodDelivery.Data.RepositoryDirectory
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category{get; private set;}
        public IFoodTypeRepository FoodType{get; private set;}
        public IMenuItemRepository MenuItem{get; private set;}

        // private set is used to set the repo only in constructor
        private readonly ApplicationDbContext db;

        public UnitOfWork(ApplicationDbContext _db)
        {
            db = _db;
            Category = new CategoryRepository(_db);
            FoodType = new FoodTypeRepository(_db);
            MenuItem = new MenuItemRepository(_db);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}