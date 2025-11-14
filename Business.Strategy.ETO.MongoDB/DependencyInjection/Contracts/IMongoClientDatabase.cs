using MongoDB.Driver;

namespace Business.Strategy.ETO.MongoDB.DependencyInjection.Contracts
{
    public interface IMongoClientDatabase
    {
        IMongoClient MongoClient { get; }
        IMongoDatabase Database { get; }    
    }
}
