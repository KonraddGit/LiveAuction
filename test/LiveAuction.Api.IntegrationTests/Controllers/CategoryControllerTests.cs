using FluentAssertions;
using FluentAssertions.Execution;
using LiveAuction.Api.IntegrationTests.Base;
using LiveAuction.Application.Features.Categories.Queries.GetCategoriesList;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Text.Json;

namespace LiveAuction.Api.IntegrationTests.Controllers;

public class CategoryControllerTests
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public CategoryControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task ReturnsSuccessResult()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/category/all");

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<List<CategoryListVm>>
            (responseString);

        using (new AssertionScope())
        {
            result.Should().BeOfType<List<CategoryListVm>>();
            result.Should().NotBeEmpty();
        }
    }
}