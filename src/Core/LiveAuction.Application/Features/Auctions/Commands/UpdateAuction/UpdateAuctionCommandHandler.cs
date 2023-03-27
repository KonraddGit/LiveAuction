using AutoMapper;
using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Domain.Entities;
using MediatR;

namespace LiveAuction.Application.Features.Auctions.Commands.UpdateAuction;

public class UpdateAuctionCommandHandler : IRequestHandler<UpdateAuctionCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Auction> _auctionRepository;

    public UpdateAuctionCommandHandler(
        IMapper mapper,
        IAsyncRepository<Auction> auctionRepository)
    {
        _mapper = mapper;
        _auctionRepository = auctionRepository;
    }

    public async Task Handle(UpdateAuctionCommand request,
        CancellationToken cancellationToken)
    {
        var auctionToUpdate = await _auctionRepository
            .GetByIdAsync(request.AuctionId);

        _mapper.Map(request, auctionToUpdate, typeof(UpdateAuctionCommand),
            typeof(Auction));

        await _auctionRepository.UpdateAsync(auctionToUpdate);
    }
}