namespace LiveAuction.Application.Features.Auctions.Queries.GetAuctionsList;

public class AuctionListVm
{
    public Guid EventId { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}