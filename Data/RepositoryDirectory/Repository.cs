using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FoodDelivery.Data.IRepositoryDirectory;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Data.RepositoryDirectory
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext db;
        public DbSet<T> dbSet ;

        public Repository(ApplicationDbContext _db)
        {
            db=_db;
            dbSet = _db.Set<T>();
            //db.MenuItems.Include(u=>u.CategoryModel).Include(u=>u.FoodType);
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(includeProperties!= null)
            {
                foreach(var includeProperty in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter)
        {
            IQueryable<T> quary = dbSet;
            if(filter!=null)
            {
                quary = quary.Where(filter);
            }
            return quary.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}