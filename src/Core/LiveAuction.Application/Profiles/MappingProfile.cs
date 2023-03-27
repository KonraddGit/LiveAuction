using AutoMapper;
using LiveAuction.Application.Features.Auctions;
using LiveAuction.Domain.Entities;

namespace LiveAuction.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Auction, AuctionListVm>().ReverseMap();
        CreateMap<Auction, AuctionDetailVm>().ReverseMap();
        CreateMap<Category, CategoryDto>();
    }
}