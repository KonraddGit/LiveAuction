using MediatR;

namespace LiveAuction.Application.Features.Auctions.Queries.GetAuctionsList;

public class GetAuctionsListQuery : IRequest<List<AuctionListVm>>
{
}