namespace LiveAuction.Domain.Entities;

public class Auction
{
    public Guid AuctionId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastBidPlaced { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}