namespace Business.Strategy.ETO.MongoDB.Repository.Company.Contracts
{
    public interface IEntity<out TKey> : IEntity where TKey : struct
    {
        TKey Id { get; }
    }

    public interface IEntity
    { 
    }
}
