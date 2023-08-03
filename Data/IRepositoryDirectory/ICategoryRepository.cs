using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data.RepositoryDirectory;
using FoodDelivery.Models;

namespace FoodDelivery.Data.IRepositoryDirectory
{
    public interface ICategoryRepository : IRepository<CategoryModel>
    {
        public void Update(CategoryModel obj);
    }
}