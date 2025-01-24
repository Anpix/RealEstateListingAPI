using RealEstateListingApi.Models;

namespace RealEstateListingApi.Services
{
    public interface IListingService
    {
        Task<IEnumerable<Listing>> GetAll();
        Task<Listing?> GetById(string id);
        Task<Listing?> Create(Listing listing);
        Task<Listing?> Update(Listing listing);
        Task<bool> Delete(string id);
    }
}