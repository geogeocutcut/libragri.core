using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using libragri.core.common;
using libragri.core.repository;
using MongoDB.Bson;
using MongoDB.Driver;

namespace libragri.core.repository.mongodb
{
    public class StoreMongodb<TId> : IStore<TId>
    {
        private readonly IMongoDatabase database;

        public StoreMongodb(IMongoClient client,string connection)
        {
            this.database = client.GetDatabase(connection);
        }

        public async Task<IList<TEntity>> GetAllAsync<TEntity>() where TEntity:Entity<TId>
        {
            return (await this.database.GetCollection<TEntity>(typeof(TEntity).Name).FindAsync(new BsonDocument())).ToList();
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(TId id) where TEntity:Entity<TId>
        { 
            return (await this.database.GetCollection<TEntity>(typeof(TEntity).Name).FindAsync(x => x.GetId().Equals(id))).FirstOrDefault();
        }

        public async Task<IList<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity:Entity<TId>
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            return (await collection.FindAsync(predicate)).ToList();
        }

        public async Task RemoveAsync<TEntity>(TEntity entity) where TEntity:Entity<TId>
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            await collection.DeleteOneAsync(x => x.GetId().Equals(entity.GetId()));
        }

        public async Task<TEntity> UpsertAsync<TEntity>(TEntity entity) where TEntity:Entity<TId>
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            await collection.ReplaceOneAsync(
                    x => x.GetId().Equals(entity.GetId()), 
                    entity, 
                    new UpdateOptions
                    {
                        IsUpsert = true
                    }
                );
            return entity;
        }
    }
}