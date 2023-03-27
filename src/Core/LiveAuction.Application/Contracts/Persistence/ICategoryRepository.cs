using LiveAuction.Domain.Entities;

namespace LiveAuction.Application.Contracts.Persistence;

public interface ICategoryRepository : IAsyncRepository<Category>
{
    Task<List<Category>> GetCategoriesWithAuctions(bool includeHistory);
}