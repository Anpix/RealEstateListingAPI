using RealEstateListingApi.Models;

namespace RealEstateListingApi.Services
{
    public interface IListingService
    {
        Listing Create(Listing listing);
        bool Delete(string id);
        IEnumerable<Listing> GetAll();
        Listing? GetById(string id);
        Listing? Update(string id, Listing listing);
    }
}