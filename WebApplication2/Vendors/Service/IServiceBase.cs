using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication2.Vendors.RepositoryGeneric;
using WebApplication2.Vendors.Request.enforce;

namespace WebApplication2.Vendors.Service
{
    public interface IServiceBase<T>
    {
        public Task<IEnumerable<T>> All();

        public Task<T> Get(string id);

        public Task<T> CreateOrUpdate(T entity);
        public Task<T> Update(T entity);
        public Task<T> Create(T entity);

        public Task<List<T>> Create(List<T> entity);
        public void Delete(T entity);

        public void Delete(string entity);

    }
}