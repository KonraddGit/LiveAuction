using LiveAuction.Application.Features.Auctions.Commands.CreateAuction;
using LiveAuction.Application.Features.Auctions.Commands.DeleteAuction;
using LiveAuction.Application.Features.Auctions.Commands.UpdateAuction;
using LiveAuction.Application.Features.Auctions.Queries.GetAuctionDetail;
using LiveAuction.Application.Features.Auctions.Queries.GetAuctionsExport;
using LiveAuction.Application.Features.Auctions.Queries.GetAuctionsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiveAuction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : Controller
    {
        private readonly IMediator _mediator;

        public AuctionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllAuctions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<AuctionListVm>>> GetAllAuctions()
        {
            var dtos = await _mediator.Send(new GetAuctionsListQuery());

            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetAuctionById")]
        public async Task<ActionResult<AuctionDetailVm>> GetAuctionById(Guid id)
        {
            var getAuctionDetailQuery = new GetAuctionDetailQuery() { Id = id };
            var dtos = await _mediator.Send(getAuctionDetailQuery);

            return Ok(dtos);
        }

        [HttpPost(Name = "AddAuction")]
        public async Task<ActionResult<Guid>> Create([FromBody]
            CreateAuctionCommand createAuctionCommand)
        {
            var id = await _mediator.Send(createAuctionCommand);

            return Ok(id);
        }

        [HttpPut(Name = "UpdateAuction")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateAuctionCommand
            updateAuctionCommand)
        {
            await _mediator.Send(updateAuctionCommand);

            return NoContent();
        }

        [HttpPut(Name = "DeleteAuction")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteAuctionCommand = new DeleteAuctionCommand() { AuctionId = id };
            await _mediator.Send(deleteAuctionCommand);

            return NoContent();
        }

        [HttpGet("export", Name = "ExportAuctions")]
        public async Task<FileResult> ExportAuctions()
        {
            var fileDto = await _mediator.Send(new GetAuctionsExportQuery());

            return File(fileDto.Data, fileDto.ContentType,
                fileDto.AuctionExportFileName);
        }
    }
}