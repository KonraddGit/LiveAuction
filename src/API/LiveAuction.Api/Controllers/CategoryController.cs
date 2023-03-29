using LiveAuction.Application.Features.Categories.Commands.CreateCategory;
using LiveAuction.Application.Features.Categories.Queries.GetCategoriesList;
using LiveAuction.Application.Features.Categories.Queries.GetCategoriesListWithAuctions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiveAuction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());

            return Ok(dtos);
        }

        [HttpGet("allwithevents", Name = "GetCategoriesWithEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryAuctionListVm>>>
            GetCategoriesWithAuctions(bool includeHistory)
        {
            var getCategoriesListWithAuctionsQuery = new GetCategoriesListWithAuctionsQuery()
            {
                IncludeHistory = includeHistory
            };

            var dtos = await _mediator.Send(getCategoriesListWithAuctionsQuery);

            return Ok(dtos);
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create(
            [FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);

            return Ok(response);
        }
    }
}