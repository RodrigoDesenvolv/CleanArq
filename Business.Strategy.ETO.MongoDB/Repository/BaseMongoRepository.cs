using Business.Strategy.ETO.MongoDB.Context.Contracts;
using Business.Strategy.ETO.MongoDB.Repository.Company.Contracts;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Business.Strategy.ETO.MongoDB.Repository
{
    public abstract partial class BaseMongoRepositoryAsync<TEntity, TKey> : IRepositoryAsync<TEntity, TKey>
    where TKey : struct
    where TEntity : IEntity<TKey>
    {

        protected readonly IMongoContext Context;
        protected IMongoCollection<TEntity> Collection;



        protected BaseMongoRepositoryAsync(IMongoContext context, string collectionName = "")
        {
            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = typeof(TEntity).Name;
            }
            Context = context;
            Collection = Context.GetCollection<TEntity>(collectionName);
        }

        public Task<IReadOnlyList<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate, TQuery query) where TQuery : IPageQuery
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
