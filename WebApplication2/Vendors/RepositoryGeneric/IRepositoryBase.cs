using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WebApplication2.Vendors.RepositoryGeneric
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> All();
        Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> expression);
        Task<T> Get(string id);
        Task<T> CreateOrUpdate(T entity);
        Task<T> Create(T entity);
        Task<List<T>> Create(List<T> entity);
        Task<T> Update(T entity);
        void Delete(T entity);
        void Delete(string entity);
        public IMongoCollection<T> getCollectionEq();
    }
}