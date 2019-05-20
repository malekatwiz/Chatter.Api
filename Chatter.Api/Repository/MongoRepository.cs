using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Chatter.Api.Repository
{
    public class MongoRepository : IRepository
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _db;

        public MongoRepository(string connectionString, string dbName)
        {
            _mongoClient = new MongoClient(connectionString);
            _db = _mongoClient.GetDatabase(dbName);
        }

        public IEnumerable<T> All<T>()
        {
            return GetCollection<T>().AsQueryable();
        }

        public T Find<T>(Expression<Func<T, bool>> predicate)
        {
            return GetCollection<T>().AsQueryable().Where(predicate).FirstOrDefault();
        }

        public Task Insert<T>(T item, CancellationToken cancellationToken)
        {
            var collection = GetCollection<T>();
            return collection.InsertOneAsync(item, new InsertOneOptions(), cancellationToken);
        }

        public Task Update<T>(T item, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private IMongoCollection<T> GetCollection<T>(string collectionName = "")
        {
            return string.IsNullOrEmpty(collectionName) ?
                _db.GetCollection<T>(typeof(T).Name.ToLower()) :
                _db.GetCollection<T>(collectionName);
        }
    }
}
