namespace Business.Strategy.ETO.Domain.ExternalFactors
{
    public class ExternalFactorsEntity
    {
        public string Economic { get; private set; }
        public string Technological { get; private set; }

        public ExternalFactorsEntity(string economic, string technological)
        {
            Economic = economic;
            Technological = technological;
        }
    }
}
