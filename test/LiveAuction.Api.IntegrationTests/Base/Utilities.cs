using LiveAuction.Domain.Entities;
using LiveAuction.Persistence;

namespace LiveAuction.Api.IntegrationTests.Base;

public class Utilities
{
    public static void InitializeDbForTests(LiveAuctionDbContext context)
    {
        var fruitsGuid = Guid.NewGuid();
        var clothesGuid = Guid.NewGuid();
        var carsGuid = Guid.NewGuid();

        context.Categories.Add(new Category
        {
            CategoryId = fruitsGuid,
            Name = "Fruits"
        });
        context.Categories.Add(new Category
        {
            CategoryId = clothesGuid,
            Name = "Clothes"
        });
        context.Categories.Add(new Category
        {
            CategoryId = carsGuid,
        });

        context.SaveChanges();
    }
}