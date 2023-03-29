using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LiveAuction.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection
        services, IConfiguration configuration)
    {
        services.AddDbContext<LiveAuctionDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(
                    "LiveAuctionConnectionString")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IAuctionRepository, AuctionRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}