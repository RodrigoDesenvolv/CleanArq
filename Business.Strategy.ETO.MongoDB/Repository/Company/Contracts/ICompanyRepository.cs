using Business.Strategy.ETO.Domain.Company;

namespace Business.Strategy.ETO.MongoDB.Repository.Company.Contracts
{
    public interface ICompanyRepository
    {
        Task<CompanyEntity> AddAsync(CompanyEntity entity, CancellationToken cancellationToken = default);
    }
}
