namespace Business.Strategy.ETO.MongoDB.Repository.Company.Contracts
{
    public interface ICreateDataAsync<TEntity, TKey> where TEntity : IEntity<TKey> where TKey : struct
    {
        Task<int> CreateAsync(TEntity entity,CancellationToken cancellationToken = default);
    }
}
