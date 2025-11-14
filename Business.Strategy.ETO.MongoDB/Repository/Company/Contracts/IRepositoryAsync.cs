using System.Linq.Expressions;

namespace Business.Strategy.ETO.MongoDB.Repository.Company.Contracts
{
    public interface IRepositoryAsync<TEntity,TKey> : ICreateDataAsync<TEntity,TKey>, IReadDataAsync<TEntity,TKey>, IUpdateDataAsync<TEntity,TKey>,IDeleteDataAsync<TEntity,TKey> where TEntity : IEntity<TKey> where TKey : struct
    {

    }
}
