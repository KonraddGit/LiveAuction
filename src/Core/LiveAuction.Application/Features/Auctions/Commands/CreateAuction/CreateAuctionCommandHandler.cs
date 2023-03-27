using AutoMapper;
using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Domain.Entities;
using MediatR;

namespace LiveAuction.Application.Features.Auctions.Commands.CreateAuction;

public class CreateAuctionCommandHandler :
    IRequestHandler<CreateAuctionCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IAuctionRepository _auctionRepository;

    public CreateAuctionCommandHandler(
        IMapper mapper,
        IAuctionRepository auctionRepository)
    {
        _mapper = mapper;
        _auctionRepository = auctionRepository;
    }

    public async Task<Guid> Handle(CreateAuctionCommand request,
        CancellationToken cancellationToken)
    {
        var auction = _mapper.Map<Auction>(request);

        auction = await _auctionRepository.AddAsync(auction);

        return auction.AuctionId;
    }
}