using MediatR;

namespace LiveAuction.Application.Features.Auctions.Commands.CreateAuction;

public class CreateAuctionCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string? Owner { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; }

    public override string ToString()
        => $"Auction name: {Name}; Price: {Price}; By: {Owner}; " +
            $"On:{CreatedDate.ToShortDateString()}; Description: {Description}";
}