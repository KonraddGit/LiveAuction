using AutoMapper;
using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Domain.Entities;
using MediatR;

namespace LiveAuction.Application.Features.Auctions.Queries.GetAuctionsList;

public class GetAuctionsListQueryHandler : IRequestHandler<GetAuctionsListQuery,
    List<AuctionListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Auction> _auctionRepository;

    public GetAuctionsListQueryHandler(
        IMapper mapper,
        IAsyncRepository<Auction> auctionRepository)
    {
        _mapper = mapper;
        _auctionRepository = auctionRepository;
    }
    public async Task<List<AuctionListVm>> Handle(GetAuctionsListQuery request,
        CancellationToken cancellationToken)
    {
        var allAuctions = (await _auctionRepository.ListAllAsync()).OrderBy(x =>
            x.CreatedDate);

        return _mapper.Map<List<AuctionListVm>>(allAuctions);
    }
}