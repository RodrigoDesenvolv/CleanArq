namespace Business.Strategy.ETO.Domain.GrowthAvenue
{
    public class GrowthAvenueEntity
    {
        public string Type { get; private set; }
        public string Description { get; private set; }

        public GrowthAvenueEntity(string type, string description)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}
