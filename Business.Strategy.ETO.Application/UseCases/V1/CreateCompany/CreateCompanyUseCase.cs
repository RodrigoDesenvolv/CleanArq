using Business.Strategy.ETO.Application.Output;
using Business.Strategy.ETO.Domain.Shared.Services;

namespace Business.Strategy.ETO.Application.UseCases.V1.CreateCompany
{
    public class CreateCompanyUseCase : ICreateCompanyUseCase
    {
        public Task<Result<Output<CreateCompanyOutput>>> HandleAsync(CreateCompanyInput input, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
