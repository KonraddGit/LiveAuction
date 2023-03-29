using LiveAuction.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LiveAuction.Api.IntegrationTests.Base;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    private const string DatabaseName = "LiveAuctionDbContextInMemoryTest";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddDbContext<LiveAuctionDbContext>(options =>
            {
                options.UseInMemoryDatabase(DatabaseName);
            });

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<LiveAuctionDbContext>();
            var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TProgram>>>();

            context.Database.EnsureCreated();

            try
            {
                Utilities.InitializeDbForTests(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred seeding db, Error: {0}", ex.Message);
            }
        });
    }
}