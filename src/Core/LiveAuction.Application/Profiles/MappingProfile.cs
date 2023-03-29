using AutoMapper;
using LiveAuction.Application.Features.Auctions.Queries.GetAuctionDetail;
using LiveAuction.Application.Features.Auctions.Queries.GetAuctionsList;
using LiveAuction.Application.Features.Categories.Commands.CreateCategory;
using LiveAuction.Application.Features.Categories.Queries.GetCategoriesList;
using LiveAuction.Application.Features.Categories.Queries.GetCategoriesListWithAuctions;
using LiveAuction.Domain.Entities;

namespace LiveAuction.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Auction, AuctionListVm>().ReverseMap();
        CreateMap<Auction, AuctionDetailVm>().ReverseMap();
        CreateMap<Category, CategoryDto>();
        CreateMap<Category, CategoryListVm>();
        CreateMap<Category, CategoryAuctionListVm>();

        CreateMap<Category, CategoryDto>();
        CreateMap<Category, CategoryListVm>();
        CreateMap<Category, CategoryAuctionListVm>();
        CreateMap<Category, CreateCategoryCommand>();
        CreateMap<Category, CreateCategoryDto>();
    }
}