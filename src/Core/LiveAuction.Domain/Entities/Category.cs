using LiveAuction.Domain.Common;

namespace LiveAuction.Domain.Entities;

public class Category : CommonInfoEntity
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Auction>? Auctions { get; set; }
}