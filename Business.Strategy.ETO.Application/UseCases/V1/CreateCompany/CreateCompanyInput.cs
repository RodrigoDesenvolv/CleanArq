using Business.Strategy.ETO.Application.Output;
using MediatR;

namespace Business.Strategy.ETO.Application.UseCases.V1.CreateCompany
{
    public class CreateCompanyInput : IRequest<Output<CreateCompanyOutput>>
    {
        public CreateCompanyData Data { get; set; }
    }
}
