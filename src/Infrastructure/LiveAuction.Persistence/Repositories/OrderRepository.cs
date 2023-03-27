using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Domain.Entities;

namespace LiveAuction.Persistence.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(LiveAuctionDbContext context) : base(context)
    {
    }
}