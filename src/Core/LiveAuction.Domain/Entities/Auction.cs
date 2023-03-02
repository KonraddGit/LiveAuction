using LiveAuction.Domain.Common;

namespace LiveAuction.Domain.Entities;

public class Auction : CommonInfoEntity
{
    public Guid AuctionId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}