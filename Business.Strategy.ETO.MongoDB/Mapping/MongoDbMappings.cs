using Business.Strategy.ETO.MongoDB.Context.Contracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Business.Strategy.ETO.MongoDB.Mapping
{
    public class MongoDbMappings
    {
        private static GuidSerializer guidSerializer = new GuidSerializer(BsonType.String);
        private readonly IMongoContext _context;

        public MongoDbMappings(IMongoContext mongoContext)
        {
            _context = mongoContext;
        }


        public void AppplyConfiguration()
        {
            BsonSerializer.TryRegisterSerializer(guidSerializer);
            CompanyEntityMap.Configure();
        }

    }
}
