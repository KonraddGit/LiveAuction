using AutoMapper;
using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Domain.Entities;
using MediatR;

namespace LiveAuction.Application.Features.Auctions.Queries.GetAuctionDetail;

public class GetAuctionDetailQueryHandler : IRequestHandler<GetAuctionDetailQuery,
    AuctionDetailVm>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Auction> _auctionRepository;
    private readonly IAsyncRepository<Category> _categoryRepository;

    public GetAuctionDetailQueryHandler(
        IMapper mapper,
        IAsyncRepository<Auction> auctionRepository,
        IAsyncRepository<Category> categoryRepository)
    {
        _mapper = mapper;
        _auctionRepository = auctionRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<AuctionDetailVm> Handle(GetAuctionDetailQuery request,
        CancellationToken cancellationToken)
    {
        var auction = await _auctionRepository.GetByIdAsync(request.Id);
        var auctionDetailDto = _mapper.Map<AuctionDetailVm>(auction);

        var category = await _categoryRepository.GetByIdAsync(auction.CategoryId);

        auctionDetailDto.Category = _mapper.Map<CategoryDto>(category);

        return auctionDetailDto;
    }
}