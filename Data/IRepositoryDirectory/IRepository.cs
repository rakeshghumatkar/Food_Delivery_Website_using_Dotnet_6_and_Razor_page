using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodDelivery.Data.IRepositoryDirectory
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T,bool>>? filter = null,
        Func<IQueryable<T>,IQueryable<T>>? orderby = null, string? includeProperties = null);
        T GetFirstOrDefault(Expression<Func<T,bool>>? filter, string? includeProperties = null);

        void Add(T entity);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}