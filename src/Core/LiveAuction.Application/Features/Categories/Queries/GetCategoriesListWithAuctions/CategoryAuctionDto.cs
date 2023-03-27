namespace LiveAuction.Application.Features.Categories.Queries.GetCategoriesListWithAuctions;

public class CategoryAuctionDto
{
    public Guid AuctionId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Owner { get; set; }
    public int Price { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid CategoryId { get; set; }
}