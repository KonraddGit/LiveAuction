namespace LiveAuction.Application.Features.Auctions.Queries.GetAuctionDetail;

public class AuctionDetailVm
{
    public Guid AuctionId { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Price { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Owner { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public CategoryDto Category { get; set; } = default!;
}