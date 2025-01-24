using AutoMapper;
using RealEstateListingApi.DTOs;
using RealEstateListingApi.Models;

namespace RealEstateListingApi.Mappers;

public class ListingMapperProfiles : Profile
{
    public ListingMapperProfiles()
    {
        CreateMap<Listing, ListingDto>().ReverseMap();
        CreateMap<CreateListingDto, Listing>();
    }
}
