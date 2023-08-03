using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Models;

namespace FoodDelivery.Data.IRepositoryDirectory
{
    public interface IFoodTypeRepository : IRepository<FoodType>
    {
        public void Update(FoodType food);
    }
}