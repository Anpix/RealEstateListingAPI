using RealEstateListingApi.DTOs;

namespace RealEstateListingApi.Services
{
    public interface IListingService
    {
        Task<IEnumerable<ListingDto>> GetAll();
        Task<ListingDto?> GetById(Guid id);
        Task<ListingDto?> Create(CreateListingDto listing);
        Task<bool> Delete(Guid id);
    }
}