using Business.Strategy.ETO.Domain.Financial;
using Business.Strategy.ETO.Domain.IndustryData;
using Business.Strategy.ETO.Domain.Shared.Enums;
using Business.Strategy.ETO.Domain.StrategicDirection;
using Business.Strategy.ETO.Domain.StrategicScope;

namespace Business.Strategy.ETO.Domain.Company
{
    public class CompanyEntity : AggregateBase<Guid>
    {
        public const string COLLECTION_NAME = "BusinessStrategy";

        public string? Name { get; private set; }
        public Sector Sector { get; private set; }
        public Size Size { get; private set; }
        public long AnnualRevenue { get; private set; }
        public OperatingRegion OperatingRegion { get; private set; }
        public IndustryDataEntity? IndustryData { get; private set; }
        public FinancialEntity? FinancialEntity { get; private set; }
        public StrategicScopeEntity? StrategicScope { get; private set; }
        public StrategicDirectionEntity? StrategicDirectionEntity { get; private set; }


    }
}
