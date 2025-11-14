using Business.Strategy.ETO.Domain.Shared.Enums;

namespace Business.Strategy.ETO.MongoDB.Repository.Company.Contracts
{
    public interface IPageQuery
    {
        int Page { get; }
        int Results {  get; }
        string OrderBy { get; }
        
        SortOrder SortOrder {  get; } 
    }
}
