using Business.Strategy.ETO.Application.Output;

namespace Business.Strategy.ETO.Api.Transport
{
    public static partial class OutputExtensions
    {
        public static Response<T> MapToResponse<T>(this Output<T> output)
        {
            var getCompanyByIdOutput = output.GetResult();

            var response = new Response<T>(getCompanyByIdOutput);

            response.AddMessages(output.Messages.ToArray());
            response.AddErrorMessages(output.ErrorMessages.ToArray());

            return response;
        }

        public static Response MapToResponse(this Output output)
        {
            var _ = output.GetResult() ?? new object();
            var response = new Response(_);

            response.AddMessages(output.Messages.ToArray()); 
            response.AddErrorMessages(output.ErrorMessages?.ToArray());
            return response;
        }

        public static Response MapToErrorsResponse<T>(this Output<T> output)
            => new Response(output.ErrorMessages,false);



    }
}
