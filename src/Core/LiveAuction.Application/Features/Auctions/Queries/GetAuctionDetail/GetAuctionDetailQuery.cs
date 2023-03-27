using MediatR;

namespace LiveAuction.Application.Features.Auctions.Queries.GetAuctionDetail;

public class GetAuctionDetailQuery : IRequest<AuctionDetailVm>
{
    public Guid Id { get; set; }
}