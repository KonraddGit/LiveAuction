namespace LiveAuction.Application.Features.Auctions.Queries.GetAuctionsExport;

public class AuctionExportFileVm
{
    public string AuctionExportFileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public byte[]? Data { get; set; }
}