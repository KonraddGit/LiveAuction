using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Domain.Entities;

namespace LiveAuction.Persistence.Repositories;

public class AuctionRepository : BaseRepository<Auction>, IAuctionRepository
{
    public AuctionRepository(LiveAuctionDbContext context) : base(context)
    {
    }

    public Task<bool> IsAuctionNameAndDateUnique(string name, DateTime auctionDate)
    {
        var matches = _context.Auctions.Any(e => e.Name.Equals(name) &&
            e.CreatedDate.Date.Equals(auctionDate.Date));

        return Task.FromResult(matches);
    }
}