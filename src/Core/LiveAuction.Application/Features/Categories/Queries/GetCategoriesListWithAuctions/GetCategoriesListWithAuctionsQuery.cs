using MediatR;

namespace LiveAuction.Application.Features.Categories.Queries.GetCategoriesListWithAuctions;

public class GetCategoriesListWithAuctionsQuery : IRequest<List<CategoryAuctionListVm>>
{
    public bool IncludeHistory { get; set; }
}