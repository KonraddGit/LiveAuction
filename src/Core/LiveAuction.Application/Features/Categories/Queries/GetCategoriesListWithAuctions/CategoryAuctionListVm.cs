namespace LiveAuction.Application.Features.Categories.Queries.GetCategoriesListWithAuctions;

public class CategoryAuctionListVm
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<CategoryAuctionDto>? Auctions { get; set; }
}