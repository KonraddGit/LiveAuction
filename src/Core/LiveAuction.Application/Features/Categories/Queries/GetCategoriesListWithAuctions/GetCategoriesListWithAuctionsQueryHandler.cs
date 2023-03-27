using AutoMapper;
using LiveAuction.Application.Contracts.Persistence;
using MediatR;

namespace LiveAuction.Application.Features.Categories.Queries.GetCategoriesListWithAuctions;

public class GetCategoriesListWithAuctionsQueryHandler :
    IRequestHandler<GetCategoriesListWithAuctionsQuery, List<CategoryAuctionListVm>>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesListWithAuctionsQueryHandler(
        IMapper mapper,
        ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryAuctionListVm>> Handle(
        GetCategoriesListWithAuctionsQuery request,
        CancellationToken cancellationToken)
    {
        var list = await _categoryRepository.GetCategoriesWithAuctions(
            request.IncludeHistory);

        return _mapper.Map<List<CategoryAuctionListVm>>(list);
    }
}