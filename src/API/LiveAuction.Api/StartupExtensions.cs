using LiveAuction.Application;
using LiveAuction.Infrastructure;
using LiveAuction.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LiveAuction.Api;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(
        this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);

        builder.Services.AddControllers();
        builder.Services.AddCors(options =>
        {
            options
                .AddPolicy("Open", builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }

    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        try
        {
            var context = scope.ServiceProvider.GetService<LiveAuctionDbContext>();

            if (context != null)
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            //
        }
    }
}