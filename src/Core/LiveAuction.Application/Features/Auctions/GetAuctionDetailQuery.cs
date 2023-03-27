using MediatR;

namespace LiveAuction.Application.Features.Auctions;

public class GetAuctionDetailQuery : IRequest<AuctionDetailVm>
{
    public Guid Id { get; set; }
}