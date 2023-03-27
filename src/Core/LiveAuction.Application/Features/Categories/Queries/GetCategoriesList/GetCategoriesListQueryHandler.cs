using AutoMapper;
using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Domain.Entities;
using MediatR;

namespace LiveAuction.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery,
    List<CategoryListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Category> _categoryRepository;

    public GetCategoriesListQueryHandler(
        IMapper mapper,
        IAsyncRepository<Category> categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request,
        CancellationToken cancellationToken)
    {
        var allCategories = (await _categoryRepository
            .ListAllAsync())
            .OrderBy(x => x.Name);

        return _mapper.Map<List<CategoryListVm>>(allCategories);
    }
}