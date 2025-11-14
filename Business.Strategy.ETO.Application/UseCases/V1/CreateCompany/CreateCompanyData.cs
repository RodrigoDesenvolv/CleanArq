using Business.Strategy.ETO.Domain.Shared.Enums;

namespace Business.Strategy.ETO.Application.UseCases.V1.CreateCompany
{
    public class CreateCompanyData
    {
        public string? Name { get;  set; }
        public Sector Sector { get;  set; }
        public Size Size { get;  set; }
        public long AnnualRevenue { get;  set; }
        public OperatingRegion OperatingRegion { get;  set; }
    }
}
