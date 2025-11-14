namespace Business.Strategy.ETO.MongoDB.Repository.Company.Contracts
{
    public interface IUpdateDataAsync<TEntity, TKey> where TEntity : IEntity<TKey> where TKey : struct
    {
        Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
