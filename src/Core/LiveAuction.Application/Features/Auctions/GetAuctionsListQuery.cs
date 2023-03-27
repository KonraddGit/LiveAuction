using MediatR;

namespace LiveAuction.Application.Features.Auctions;

public class GetAuctionsListQuery : IRequest<List<AuctionListVm>>
{
}