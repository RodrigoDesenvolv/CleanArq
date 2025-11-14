namespace Business.Strategy.ETO.MongoDB.Repository.Company.Contracts
{
    public interface IDeleteDataAsync<TEntity, TKey> where TEntity : IEntity<TKey> where TKey : struct
    {
        Task<int> Delete(TEntity entity,CancellationToken cancellationToken = default);
    }
}
