using CsvHelper;
using LiveAuction.Application.Contracts.Infrastructure;
using LiveAuction.Application.Features.Auctions.Queries.GetAuctionsExport;
using System.Globalization;

namespace LiveAuction.Infrastructure.FileExport;

public class CsvExporter : ICsvExporter
{
    public byte[] ExportAuctionToCsv(List<AuctionExportDto> auctionExportDtos)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.CurrentCulture);
            csvWriter.WriteRecords(auctionExportDtos);
        }

        return memoryStream.ToArray();
    }
}