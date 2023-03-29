using AutoMapper;
using LiveAuction.Application.Contracts.Infrastructure;
using LiveAuction.Application.Contracts.Persistence;
using LiveAuction.Domain.Entities;
using MediatR;

namespace LiveAuction.Application.Features.Auctions.Queries.GetAuctionsExport;

public class GetAuctionsExportQueryHandler : IRequestHandler<GetAuctionsExportQuery,
    AuctionExportFileVm>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Auction> _auctionRepository;
    private readonly ICsvExporter _csvExporter;

    public GetAuctionsExportQueryHandler(
        IMapper mapper,
        IAsyncRepository<Auction> auctionRepository,
        ICsvExporter csvExporter)
    {
        _mapper = mapper;
        _auctionRepository = auctionRepository;
        _csvExporter = csvExporter;
    }

    public async Task<AuctionExportFileVm> Handle(GetAuctionsExportQuery request, CancellationToken cancellationToken)
    {
        var allAuctions = _mapper
            .Map<List<AuctionExportDto>>((await _auctionRepository
            .ListAllAsync())
            .OrderBy(x => x.CreatedDate));

        var fileData = _csvExporter.ExportAuctionToCsv(allAuctions);

        var auctionsExportFileDto = new AuctionExportFileVm()
        {
            ContentType = "text/csv",
            Data = fileData,
            AuctionExportFileName = $"{Guid.NewGuid()}.csv"
        };

        return auctionsExportFileDto;
    }
}