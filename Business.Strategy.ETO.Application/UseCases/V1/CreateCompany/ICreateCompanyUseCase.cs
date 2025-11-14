using Business.Strategy.ETO.Application.Output;
using Business.Strategy.ETO.Domain.Contracts.Services;

namespace Business.Strategy.ETO.Application.UseCases.V1.CreateCompany
{
    public interface ICreateCompanyUseCase : IUseCase<CreateCompanyInput,Output<CreateCompanyOutput>>
    {
    }
}
