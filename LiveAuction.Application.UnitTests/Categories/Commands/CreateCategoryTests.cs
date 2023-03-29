using AutoMapper;
using FluentAssertions;
using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Application.Features.Categories.Commands.CreateCategory;
using LiveAuction.Application.Profiles;
using LiveAuction.Application.UnitTests.Mock;
using LiveAuction.Domain.Entities;
using Moq;

namespace LiveAuction.Application.UnitTests.Categories.Commands;

public class CreateCategoryTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

    public CreateCategoryTests()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidCategory_AddedToCategoriesRepo()
    {
        var handler = new CreateCategoryCommandHandler(_mapper,
            _mockCategoryRepository.Object);

        await handler.Handle(new CreateCategoryCommand() { Name = "Test" },
            CancellationToken.None);

        var allCategories = await _mockCategoryRepository.Object.ListAllAsync();

        allCategories.Count.Should().Be(4);
    }
}