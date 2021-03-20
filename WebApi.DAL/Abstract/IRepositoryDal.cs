using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbObject;

namespace WebApi.DAL.Abstract
{
    public interface IRepositoryDal<T> where T : class, IEntity, new()
    {
        IList<T> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);
        T Get(int id);
        void Add(T entity);
        void AddBulk(List<T> entity);
        void HardDelete(int id);
        void HardDelete(T entity);
        void SoftDelete(int id);
        void SoftDelete(T entity);
        void Update(T entity);
    }
}
