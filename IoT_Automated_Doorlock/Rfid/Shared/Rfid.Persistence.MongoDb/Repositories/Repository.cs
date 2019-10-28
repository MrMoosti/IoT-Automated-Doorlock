using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Rfid.Persistence.Domain;
using Rfid.Persistence.Repositories;

namespace Rfid.Persistence.MongoDb.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseBsonDocument
    {

        private readonly IMongoCollection<T> _mongoCollection;


        /// <inheritdoc />
        protected Repository(MongoContext context, string collectionName)
        {
            _mongoCollection = context.GetCollection<T>(collectionName);
        }

        public List<T> GetLastDocuments(int count)
        {
            return _mongoCollection.AsQueryable().OrderByDescending(x => x.UnixTime).Take(count).ToList();
        }

        /// <inheritdoc />
        public Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return _mongoCollection.Find(predicate).FirstOrDefaultAsync();
        }


        /// <inheritdoc />
        public Task<List<T>> GetAllAsync()
        {
            return _mongoCollection.Find(FilterDefinition<T>.Empty).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _mongoCollection.Find(predicate).ToListAsync().ConfigureAwait(false);
        }


        /// <inheritdoc />
        public Task AddAsync(T document)
        {
            return _mongoCollection.InsertOneAsync(document);
        }


        /// <inheritdoc />
        public Task AddRangeAsync(IEnumerable<T> documents)
        {
            return _mongoCollection.InsertManyAsync(documents);
        }


        /// <inheritdoc />
        public Task<DeleteResult> RemoveAsync(ObjectId objectId)
        {
            return _mongoCollection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", objectId));
        }


        /// <inheritdoc />
        public Task<DeleteResult> RemoveRangeAsync(List<ObjectId> objectIds)
        {
            return _mongoCollection.DeleteManyAsync(Builders<T>.Filter.In("_id", objectIds));
        }


        /// <inheritdoc />
        public Task UpdateValue(Expression<Func<T, object>> predicateSearch, object searchValue, Expression<Func<T, object>> predicateNew, object newValue)
        {
            var filter = Builders<T>.Filter.Eq(predicateSearch, searchValue);
            var update = Builders<T>.Update.Set(predicateNew, newValue);
            return _mongoCollection.FindOneAndUpdateAsync(filter, update);
        }
    }
}
