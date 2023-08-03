using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data.RepositoryDirectory;
using FoodDelivery.Models;

namespace FoodDelivery.Data.IRepositoryDirectory
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        public void Update(MenuItem obj);
    }
}