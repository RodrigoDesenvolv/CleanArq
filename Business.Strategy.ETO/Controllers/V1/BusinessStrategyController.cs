using Business.Strategy.ETO.Domain.Shared.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Business.Strategy.ETO.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ProducesResponseType(typeof(Application.Output.Response), StatusCodes.Status500InternalServerError)]
    public abstract class BusinessStrategyController<T> : ControllerBase where T : class
    {
        protected readonly ILogger<T> Logger;

        protected BusinessStrategyController(ILogger<T> logger)
        {
            Logger = logger;
        }

        protected IActionResult HandleFailedResult(Error error)
        {
            return error.Code switch
            {
                "400" => BadRequest(error),
                "401" => Unauthorized(error),
                "403" => StatusCode(403,error),
                "404" => NotFound(error),
                "406" => StatusCode(406, error),
                "409" => Conflict(error),
                "422" => UnprocessableEntity(error),
                _ => StatusCode(500, error)
            };
        }

        public override OkObjectResult Ok([ActionResultObjectValue] object? value)
        {
            Logger.LogInformation("Return status {Status}", "Ok");
            return base.Ok(value);
        }
        public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object error)
        {
            Logger.LogInformation("Return status {Status}", "BadRequest");
            return base.BadRequest(error);
        }

        public override UnauthorizedObjectResult Unauthorized([ActionResultObjectValue] object error)
        {
            Logger.LogInformation("Return status {Status}", "Unauthorized");
            return base.Unauthorized(error);
        }

        public override NotFoundObjectResult NotFound([ActionResultObjectValue] object error)
        {
            Logger.LogInformation("Return status {Status}", "NotFound");
            return base.NotFound(error);
        }

        public override UnprocessableEntityObjectResult UnprocessableEntity([ActionResultObjectValue] object error)
        {
            Logger.LogInformation("Return status {Status}", "UnprocessableEntity");
            return base.UnprocessableEntity(error);
        }

        public override ObjectResult StatusCode([ActionResultStatusCode] int statusCode, [ActionResultObjectValue] object? value)
        {
            return base.StatusCode(statusCode, value);
        }
    }
}
