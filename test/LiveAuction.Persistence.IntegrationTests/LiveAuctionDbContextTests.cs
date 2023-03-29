using FluentAssertions;
using LiveAuction.Application.Contracts;
using LiveAuction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace LiveAuction.Persistence.IntegrationTests;

public class LiveAuctionDbContextTests
{
    private readonly LiveAuctionDbContext _liveAuctionDbContext;
    private readonly Mock<ILoggedInUserService> _mockLoggedInUserService;
    private readonly string _loggedInUserId;

    public LiveAuctionDbContextTests()
    {
        var dbContextOptions = new DbContextOptionsBuilder<LiveAuctionDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _loggedInUserId = "00000000-0000-000-000000000000";
        _mockLoggedInUserService = new Mock<ILoggedInUserService>();
        _mockLoggedInUserService.Setup(m => m.UserId).Returns(_loggedInUserId);

        _liveAuctionDbContext = new LiveAuctionDbContext(dbContextOptions,
            _mockLoggedInUserService.Object);
    }

    [Fact]
    public async void Save_SetCreatedByProperty()
    {
        var auction = new Auction() { AuctionId = Guid.NewGuid(), Name = "Test auction" };

        _liveAuctionDbContext.Auctions.Add(auction);
        await _liveAuctionDbContext.SaveChangesAsync();

        auction.CreatedBy.Should().Be(_loggedInUserId);
    }
}