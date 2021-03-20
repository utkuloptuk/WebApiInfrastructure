using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Abstract;
using WebApi.DbObject;

namespace WebApi.DAL.Concrete.EntityFramework
{
    public class EFRepositoryDal<T> : IRepositoryDal<T> where T : class, IEntity, new()
    {
        protected DbContext dbContext;
        public EFRepositoryDal(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().AddAsync(entity);
            dbContext.SaveChanges();
        }
        public void AddBulk(List<T> entity)
        {
            dbContext.BulkInsert(entity);
            dbContext.SaveChanges();
        }

        public T Get(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public IList<T> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbContext.Set<T>();
            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public void HardDelete(int id)
        {
            T entity = dbContext.Set<T>().Find(id);
            HardDelete(entity);
        }

        public void HardDelete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }

        public void SoftDelete(int id)
        {
            T entity = dbContext.Set<T>().Find(id);
            SoftDelete(entity);
        }

        public void SoftDelete(T entity)
        {
            Update(entity);

        }

        public void Update(T entity)
        {
            var tEntity = dbContext.Entry<T>(entity);
            tEntity.State = EntityState.Modified;
            dbContext.SaveChanges();
        }

    }
}
