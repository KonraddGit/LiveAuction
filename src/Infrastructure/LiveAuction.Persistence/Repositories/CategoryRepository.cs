using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiveAuction.Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(LiveAuctionDbContext context) : base(context)
    {
    }

    public async Task<List<Category>> GetCategoriesWithAuctions(bool includeHistory)
    {
        var allCategories = await _context.Categories
            .Include(x => x.Auctions)
            .ToListAsync();

        if (!includeHistory)
        {
            allCategories
                .ForEach(p => p.Auctions
                .ToList()
                .RemoveAll(c => c.CreatedDate < DateTime.Today));
        }

        return allCategories;
    }
}