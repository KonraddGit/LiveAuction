using LiveAuction.Domain.Common;
using LiveAuction.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiveAuction.Persistence;

public class LiveAuctionDbContext : DbContext
{
    public LiveAuctionDbContext(DbContextOptions<LiveAuctionDbContext> options)
        : base(options)
    {
    }

    public DbSet<Auction> Auctions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(
            LiveAuctionDbContext).Assembly);

        var foodGuid = Guid.NewGuid();
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = foodGuid,
            Name = "Food"
        });

        var clothesGuid = Guid.NewGuid();
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = clothesGuid,
            Name = "Clothes"
        });

        modelBuilder.Entity<Auction>().HasData(new Auction
        {
            AuctionId = Guid.NewGuid(),
            Name = "Candy",
            Price = 25,
            CreatedDate = DateTime.Now.AddDays(7),
            Description = "Taste delisious candies.",
            CategoryId = foodGuid
        });

        modelBuilder.Entity<Auction>().HasData(new Auction
        {
            AuctionId = Guid.NewGuid(),
            Name = "Gucci",
            Price = 400,
            CreatedDate = DateTime.Now.AddDays(7),
            Description = "The best clothes on the planet.",
            CategoryId = clothesGuid
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<CommonInfoEntity>())
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                default:
                    break;
            }

        return base.SaveChangesAsync(cancellationToken);
    }
}