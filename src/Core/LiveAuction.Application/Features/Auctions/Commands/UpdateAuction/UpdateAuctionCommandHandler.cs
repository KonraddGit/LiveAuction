using AutoMapper;
using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Application.Exceptions;
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
        var auctionToUpdate = await _auctionRepository.GetByIdAsync(request.AuctionId);

        if (auctionToUpdate is null)
            throw new NotFoundException(nameof(Auction), request.AuctionId);

        var validator = new UpdateAuctionCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        _mapper.Map(request, auctionToUpdate, typeof(UpdateAuctionCommand),
            typeof(Auction));

        await _auctionRepository.UpdateAsync(auctionToUpdate);
    }
}