using MediatR;

namespace LiveAuction.Application.Features.Auctions.Commands.UpdateAuction;

public class UpdateAuctionCommand : IRequest
{
    public Guid AuctionId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string? Owner { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
}