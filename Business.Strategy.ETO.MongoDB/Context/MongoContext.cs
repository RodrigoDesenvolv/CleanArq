using Business.Strategy.ETO.MongoDB.Context.Contracts;
using Business.Strategy.ETO.MongoDB.Context.Events.Contracts;
using Business.Strategy.ETO.MongoDB.DependencyInjection.Contracts;
using MongoDB.Driver;

namespace Business.Strategy.ETO.MongoDB.Context
{
    public sealed class MongoContext : IMongoContext,IDisposable
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoClient _mongoClient;
        private readonly ICollection<Func<Task>> _commands;
        public IClientSessionHandle Session { get; private set; }
        public IEventCatcher EventCatcher { get;}


        public MongoContext(IMongoClientDatabase database,IEventCatcher eventCatcher)
        {
            if (database is null)
            {
                throw new ArgumentNullException(nameof(database));

            }

            if (eventCatcher is null)
            {
                throw new ArgumentNullException(nameof(eventCatcher));
            }

            _commands = new List<Func<Task>>();
            _database = database.Database;
            _mongoClient = database.MongoClient;
            EventCatcher = eventCatcher;

        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            return _database.GetCollection<T>(name);
        }

        public Task AddCommand(Func<Task> func)
        {
            _commands.Add(func);
            return Task.CompletedTask;
        }

        public async Task<int> SaveChanges()
        {
            IClientSessionHandle clientSessionHandle2 = (Session = await _mongoClient.StartSessionAsync());
            using (clientSessionHandle2)
            {
                Session.StartTransaction();
                await Task.WhenAll(_commands.Select((Func<Task> c) => c()));
                await Session.CommitTransactionAsync();
            }
            
            return _commands.Count;

        }

        public MongoContext()
        {
            Dispose();
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
