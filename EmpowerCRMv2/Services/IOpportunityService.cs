using EmpowerCRMv2.Models;

namespace EmpowerCRMv2.Services
{
    public interface IOpportunityService
    {
        Task<List<Opportunity>> GetAllOpportunityItemsAsync();
        Task<Opportunity?> GetOpportunityItemByIdAsync(int id);
        Task AddOpportunityItemAsync(Opportunity item);
        Task UpdateOpportunityItemAsync(Opportunity item);
        Task DeleteOpportunityItemAsync(int id);
        Task<List<OpportunityStage>> GetOpportunityStagesAsync();
        Task DeleteOpportunityProductItemAsync(int oppId, int productId);
        Task AddOpportunityProductItemAsync(OpportunityProduct item);
        Task UpdateOpportunityProductItemAsync(OpportunityProduct item);
    }
}
