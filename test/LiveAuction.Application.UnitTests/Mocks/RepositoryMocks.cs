using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Domain.Entities;
using Moq;

namespace LiveAuction.Application.UnitTests.Mock;

public class RepositoryMocks
{
    public static Mock<IAsyncRepository<Category>> GetCategoryRepository()
    {
        var fruitsGuid = Guid.NewGuid();
        var clothesGuid = Guid.NewGuid();
        var carsGuid = Guid.NewGuid();

        var categories = new List<Category>
        {
            new Category
            {
                CategoryId = fruitsGuid,
                Name = "Fruits"
            },
            new Category
            {
                CategoryId = clothesGuid,
                Name = "Clothes"
            },
            new Category
            {
                CategoryId = carsGuid,
                Name = "Cars"
            }
        };

        var mockCategoryRepository = new Mock<IAsyncRepository<Category>>();

        mockCategoryRepository
            .Setup(repo => repo
            .ListAllAsync())
            .ReturnsAsync(categories);

        mockCategoryRepository
            .Setup(repo => repo
            .AddAsync(It.IsAny<Category>()))
            .ReturnsAsync((Category category) =>
            {
                categories.Add(category);
                return category;
            });

        return mockCategoryRepository;
    }
}