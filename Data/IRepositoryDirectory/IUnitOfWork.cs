using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Data.IRepositoryDirectory
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category {get;}
        IFoodTypeRepository FoodType {get; }

        IMenuItemRepository MenuItem {get; }

        void Save();
    }
}