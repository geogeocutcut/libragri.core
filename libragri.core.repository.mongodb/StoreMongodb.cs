using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using libragri.core.common;
using libragri.core.repository;

namespace libragri.core.repository.mongodb
{
    public class StoreMongodb<TId> : IStore<TId>
    {
        private readonly IMongoDatabase database;

        public StoreMongodb(IMongoClient client)
        {
            this.database = client.GetDatabase(ConfigurationManager.AppSettings["MongoDatabase"]);
        }

        public IList<TEntity> FindAll<TEntity>() where TEntity:Entity<TId>
        {
            return this.database.GetCollection<TEntity>(typeof(TEntity).Name).Find(new BsonDocument()).ToList();
        
        }

        public async Task<TEntity> FindById<TEntity>(TId id) where TEntity:Entity<TId>
        { 
            return await this.database.GetCollection<TEntity>(typeof(TEntity).Name).Find(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<IList<TEntity>> FindWhere<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity:Entity<TId>
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            return await collection.Find(predicate).ToListAsync();
        }

        public async void Remove<TEntity>(TEntity entity) where TEntity:Entity<TId>
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            collection.DeleteOneAsync(x => x.Id.Equals(entity.Id));
        }

        public async TEntity Upsert<TEntity>(TEntity entity) where TEntity:Entity<TId>
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            await collection.ReplaceOneAsync(
                    x => x.Id.Equals(entity.Id), 
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