using AutoMapper;
using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Domain.Entities;
using MediatR;

namespace LiveAuction.Application.Features.Auctions.Commands.DeleteAuction;

public class DeleteAuctionCommandHandler : IRequestHandler<DeleteAuctionCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Auction> _auctionRepository;

    public DeleteAuctionCommandHandler(
        IMapper mapper,
        IAsyncRepository<Auction> auctionRepository)
    {
        _mapper = mapper;
        _auctionRepository = auctionRepository;
    }

    public async Task Handle(DeleteAuctionCommand request,
        CancellationToken cancellationToken)
    {
        var auctionToDelete = await _auctionRepository
            .GetByIdAsync(request.AuctionId);

        await _auctionRepository.DeleteAsync(auctionToDelete);
    }
}