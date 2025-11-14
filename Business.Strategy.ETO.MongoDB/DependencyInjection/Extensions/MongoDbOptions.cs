namespace Business.Strategy.ETO.MongoDB.DependencyInjection.Extensions
{
    public partial class MongoDbOptions
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public bool Seed { get; set; }

    }
}
