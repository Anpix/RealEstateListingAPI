using RealEstateListingApi.Models;

namespace RealEstateListingApi.Repositories
{
    public interface IListingRepository
    {
        Task<Listing?> Create(Listing listing);
        Task<bool> Delete(string id);
        Task<IEnumerable<Listing>> GetAll();
        Task<Listing?> GetById(string id);
        Task<int> SaveChanges();
        Task<Listing?> Update(Listing listing);
    }
}