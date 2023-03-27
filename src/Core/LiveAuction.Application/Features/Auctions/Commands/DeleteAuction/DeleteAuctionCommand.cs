using MediatR;

namespace LiveAuction.Application.Features.Auctions.Commands.DeleteAuction;

public class DeleteAuctionCommand : IRequest
{
    public Guid AuctionId { get; set; }
}