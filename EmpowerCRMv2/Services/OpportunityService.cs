using EmpowerCRMv2.Data;
using EmpowerCRMv2.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;

namespace EmpowerCRMv2.Services
{
    public class OpportunityService: IOpportunityService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string? _userId;
        private string? _userRole;
        public OpportunityService(ApplicationDbContext context = null, IHttpContextAccessor httpContextAccessor = null)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            var claimsPrincipal = _httpContextAccessor.HttpContext.User;
            _userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _userRole = claimsPrincipal.FindFirst(ClaimTypes.Role)?.Value;
        }

        public async Task AddOpportunityItemAsync(Opportunity item)
        {
            item.CreatedDate = DateTime.UtcNow;
            item.LastModifiedDate = DateTime.UtcNow;
            _context.Opportunities.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOpportunityItemAsync(int id)
        {
            Opportunity? opportunityItem;
            if (_userRole == "Administrator")
            {
                opportunityItem = await _context.Opportunities.FirstOrDefaultAsync(o => o.Id == id);
            }
            else
            {
                opportunityItem = await _context.Opportunities.FirstOrDefaultAsync(o => o.Id == id && o.Contact.Owner.Id == _userId);
            }
            if (opportunityItem != null)
            {
                _context.Opportunities.Remove(opportunityItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Opportunity>> GetAllOpportunityItemsAsync()
        {
            if (_userRole == "Administrator")
            {
                return await _context.Opportunities.Include(o => o.Contact).Include(o => o.Stage).ToListAsync();
            }
            return await _context.Opportunities.Where(o => o.Contact.Owner.Id == _userId).Include(o => o.Contact).Include(o => o.Stage).ToListAsync();
        }

        public async Task<Opportunity?> GetOpportunityItemByIdAsync(int id)
        {
            if (_userRole == "Administrator")
            {
                return await _context.Opportunities.Include(o => o.Contact)
                                                   .Include(o => o.Stage)
                                                   .Include(o => o.UserTasks)
                                                   .Include(o => o.OpportunityProducts)
                                                   .ThenInclude(op => op.Product)
                                                   .FirstOrDefaultAsync(o => o.Id == id);
            }
            return await _context.Opportunities.Include(o => o.Contact)
                                                .Include(o => o.Stage)
                                                .Include(o => o.UserTasks)
                                                .Include(o => o.OpportunityProducts)
                                                .ThenInclude(op => op.Product)
                                                .FirstOrDefaultAsync(o => o.Id == id && o.Contact.Owner.Id == _userId);
        }

        public async Task UpdateOpportunityItemAsync(Opportunity item)
        {
            Opportunity? dbItem;
            if (_userRole == "Administrator")
            {
                dbItem = await _context.Opportunities.FirstOrDefaultAsync(o => o.Id == item.Id);
            }
            else
            {
                dbItem = await _context.Opportunities.FirstOrDefaultAsync(o => o.Id == item.Id && o.Contact.Owner.Id == _userId);
            }
            if (dbItem != null)
            {
                dbItem.Name = item.Name;
                dbItem.Amount = item.Amount;
                dbItem.CloseDate = item.CloseDate;
                dbItem.StageId = item.StageId;
                dbItem.LastModifiedDate = DateTime.UtcNow; 

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<OpportunityStage>> GetOpportunityStagesAsync()
        {
            return await _context.OpportunityStages.ToListAsync();
        }

        public async Task DeleteOpportunityProductItemAsync(int oppId, int productId)
        {
            OpportunityProduct? oppProductItem;
            oppProductItem = await _context.OpportunityProducts.FirstOrDefaultAsync(op => op.OpportunityId == oppId && op.ProductId == productId);
            
            if (oppProductItem != null)
            {
                _context.OpportunityProducts.Remove(oppProductItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddOpportunityProductItemAsync(OpportunityProduct item)
        {
            _context.OpportunityProducts.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOpportunityProductItemAsync(OpportunityProduct item)
        {
            OpportunityProduct? dbItem;

            dbItem = await _context.OpportunityProducts
                .FirstOrDefaultAsync(op => op.OpportunityId == item.OpportunityId && op.ProductId == item.ProductId);

            if (dbItem != null)
            {
                dbItem.Quantity = item.Quantity;
                dbItem.Price = item.Price;

                await _context.SaveChangesAsync();
            }
        }

    }
}
