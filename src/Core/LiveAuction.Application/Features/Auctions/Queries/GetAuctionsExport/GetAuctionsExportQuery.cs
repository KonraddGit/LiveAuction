using MediatR;

namespace LiveAuction.Application.Features.Auctions.Queries.GetAuctionsExport;

public class GetAuctionsExportQuery : IRequest<AuctionExportFileVm>
{
}