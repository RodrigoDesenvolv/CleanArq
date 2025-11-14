using Business.Strategy.ETO.Application.Output;
using Business.Strategy.ETO.Application.UseCases.V1.CreateCompany;
using Microsoft.AspNetCore.Mvc;

namespace Business.Strategy.ETO.Api.Controllers.V1
{
    [ApiVersion("1")]
    public class CompanyController : BusinessStrategyController<CompanyController>
    {
        private readonly ICreateCompanyUseCase _createCompanyUseCase;

        public CompanyController(ILogger<CompanyController> logger, ICreateCompanyUseCase createCompanyUseCase) : base(logger)
        {
            _createCompanyUseCase = createCompanyUseCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response<CreateCompanyOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCompanyAsync([FromBody] CreateCompanyInput createCompanyInput, CancellationToken cancellationToken)
        {
            var output = await _createCompanyUseCase.HandleAsync(createCompanyInput,cancellationToken).ConfigureAwait(false);

            return output.IsSuccess 
                ? Ok(output) 
                : HandleFailedResult(output.Error);
        }
    }
}
