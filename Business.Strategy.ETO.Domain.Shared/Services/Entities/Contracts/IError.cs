namespace Business.Strategy.ETO.Domain.Shared.Services.Entities.Contracts
{
    public interface IError
    {
        string Code { get; }
        string Message { get; }
        string Layer { get; }
        string ApplicationName { get; }
    }
}
