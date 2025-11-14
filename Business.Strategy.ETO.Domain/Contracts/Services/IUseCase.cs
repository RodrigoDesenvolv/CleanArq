using Business.Strategy.ETO.Domain.Shared.Services;

namespace Business.Strategy.ETO.Domain.Contracts.Services
{
    public interface IUseCase<TInput, TOutput>
    {
        Task<Result<TOutput>> HandleAsync(TInput input, CancellationToken cancellationToken);
    }
}
