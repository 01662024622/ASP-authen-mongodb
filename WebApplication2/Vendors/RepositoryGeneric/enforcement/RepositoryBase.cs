using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using WebApplication2.Vendors.Entity;
using WebApplication2.Vendors.MongoConnection;
using WebApplication2.Vendors.MongoConnection.enforcement;

namespace WebApplication2.Vendors.RepositoryGeneric.enforcement
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly IMongoCollection<T> _collection;

        public RepositoryBase(IConnectionMongoDb connection)
        {
            string collection = GenerateCollection.GetCollectionName(typeof(T));
            _collection = connection.GetConnectionDb().GetCollection<T>(collection);
        }

        public async Task<IEnumerable<T>> All()
        {
            var filter = _collection.Find(e=> true);
            var res = await filter.ToListAsync();
            return res;
        }

        public async Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> expression)
        {
            var res = await _collection.FindAsync(expression);
            
            return res.ToList();
        }

        public async Task<T> Get(string id)
        {
            var data = await _collection.Find(e => e._id == id).SingleOrDefaultAsync();
            return data;
        }

        public async Task<T> CreateOrUpdate(T entity)
        {
            if (entity._id.Equals(""))
            {
                await _collection.InsertOneAsync(entity);
                return entity;
            }
            else
            {
                await _collection.ReplaceOneAsync(book => book._id == entity._id, entity);
                return entity;
            }
        }

        public async Task<T> Create(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<List<T>> Create(List<T> entities)
        {
            await _collection.InsertManyAsync(entities);
            return entities;
        }

        public async Task<T> Update(T entity)
        {
            await _collection.ReplaceOneAsync(book => book._id == entity._id, entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _collection.DeleteOne(book => book._id == entity._id);
        }

        public void Delete(string id)
        {
            _collection.DeleteOne(book => book._id == id);
        }
        public FilterDefinition<T> FilterId(string key)
        {
            return Builders<T>.Filter.Eq("_id",key );
        }

        public IMongoCollection<T> getCollectionEq()
        {
            return _collection;
        }
    }
}