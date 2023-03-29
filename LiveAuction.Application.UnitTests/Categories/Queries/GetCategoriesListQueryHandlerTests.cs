using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Application.Features.Categories.Queries.GetCategoriesList;
using LiveAuction.Application.Profiles;
using LiveAuction.Application.UnitTests.Mock;
using LiveAuction.Domain.Entities;
using Moq;

namespace LiveAuction.Application.UnitTests.Categories.Queries;

public class GetCategoriesListQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

    public GetCategoriesListQueryHandlerTests()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task GetCategoriesListTests()
    {
        var handler = new GetCategoriesListQueryHandler(_mapper,
            _mockCategoryRepository.Object);

        var result = await handler.Handle(new GetCategoriesListQuery(),
            CancellationToken.None);

        using (new AssertionScope())
        {
            result.Should().BeOfType<List<CategoryListVm>>();
            result.Should().HaveCount(3);
        };
    }
}