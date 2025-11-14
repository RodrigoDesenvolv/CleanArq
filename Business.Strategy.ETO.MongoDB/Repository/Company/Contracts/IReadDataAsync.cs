using System.Linq.Expressions;

namespace Business.Strategy.ETO.MongoDB.Repository.Company.Contracts
{
    public interface IReadDataAsync<TEntity, TKey> 
        where TKey : struct 
        where TEntity : IEntity<TKey>
    {
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate,CancellationToken cancellationToken = default);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate, TQuery query) where TQuery : IPageQuery;
    }
}
