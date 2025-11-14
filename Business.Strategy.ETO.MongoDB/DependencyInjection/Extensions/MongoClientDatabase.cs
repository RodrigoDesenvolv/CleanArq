using Business.Strategy.ETO.MongoDB.DependencyInjection.Contracts;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Strategy.ETO.MongoDB.DependencyInjection.Extensions
{
    public sealed class MongoClientDatabase : IMongoClientDatabase
    {
        public IMongoClient MongoClient { get; }

        public IMongoDatabase Database { get; }


        public MongoClientDatabase(IOptions<MongoDbOptions> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));

            }

            MongoClient = new MongoClient(settings.Value.ConnectionString);
            Database = MongoClient.GetDatabase(settings.Value.DatabaseName);

        }
    }
}

