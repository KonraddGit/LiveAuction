using LiveAuction.Application.Features.Auctions.Queries.GetAuctionsExport;

namespace LiveAuction.Application.Contracts.Infrastructure;

public interface ICsvExporter
{
    byte[] ExportAuctionToCsv(List<AuctionExportDto> auctionExportDtos);
}