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

        public IList<TEntity> FindAll<TEntity>() where TEntity:Entity<TId>
        {
            return this.database.GetCollection<TEntity>(typeof(TEntity).Name).Find(new BsonDocument()).ToList();
        }

        public TEntity FindById<TEntity>(TId id) where TEntity:Entity<TId>
        { 
            return this.database.GetCollection<TEntity>(typeof(TEntity).Name).Find(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public IList<TEntity> FindWhere<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity:Entity<TId>
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            return collection.Find(predicate).ToList();
        }

        public void Remove<TEntity>(TEntity entity) where TEntity:Entity<TId>
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            collection.DeleteOne(x => x.Id.Equals(entity.Id));
        }

        public TEntity Upsert<TEntity>(TEntity entity) where TEntity:Entity<TId>
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            collection.ReplaceOne(
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