using Business.Strategy.ETO.MongoDB.Repository.Company.Contracts;

namespace Business.Strategy.ETO.MongoDB.SeedWork.Contracts
{
    public interface IAggregate<out TKey> : IEntity<TKey>, IEntity,IExposeEvents where TKey : struct
    {
    }
}
