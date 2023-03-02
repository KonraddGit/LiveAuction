using LiveAuction.Domain.Entities;

namespace LiveAuction.Application.Contracts.Persistence;

public interface IOrderRepository : IAsyncRepository<Order>
{
}