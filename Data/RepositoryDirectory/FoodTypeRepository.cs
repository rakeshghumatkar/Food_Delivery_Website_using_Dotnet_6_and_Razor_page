using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data.IRepositoryDirectory;
using FoodDelivery.Models;

namespace FoodDelivery.Data.RepositoryDirectory
{
    public class FoodTypeRepository : Repository<FoodDelivery.Models.FoodType>, IFoodTypeRepository
    {
        private readonly ApplicationDbContext _db ;
        public FoodTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(FoodType food)
        {
            FoodType entity = _db.FoodTypes.FirstOrDefault(x=>x.Id == food.Id);
            entity.Name = food.Name ;
            _db.FoodTypes.Update(entity);
        }
    }
}