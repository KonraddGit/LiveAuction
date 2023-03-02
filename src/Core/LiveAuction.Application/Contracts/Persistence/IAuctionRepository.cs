using LiveAuction.Domain.Entities;

namespace LiveAuction.Application.Contracts.Persistence;

public interface IAuctionRepository : IAsyncRepository<Auction>
{
}