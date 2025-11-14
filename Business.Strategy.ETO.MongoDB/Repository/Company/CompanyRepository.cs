using Business.Strategy.ETO.Domain.Company;
using Business.Strategy.ETO.MongoDB.Context.Contracts;
using Business.Strategy.ETO.MongoDB.Context.Session;
using Business.Strategy.ETO.MongoDB.Repository.Company.Contracts;

namespace Business.Strategy.ETO.MongoDB.Repository.Company
{
    public class CompanyRepository : BaseMongoRepositoryAsync<CompanyEntity, Guid>, ICompanyRepository
    {
        private readonly ISessionContext _sessionContext;

        public CompanyRepository(IMongoContext context,ISessionContext sessionContext) 
            : base(context, CompanyEntity.COLLECTION_NAME)
        {
        }

        public Task<CompanyEntity> AddAsync(CompanyEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
