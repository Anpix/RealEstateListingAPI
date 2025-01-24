using RealEstateListingApi.Models;

namespace RealEstateListingApi.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Listing> ListingRepository { get; }

        void Dispose();
        Task SaveChanges();
    }
}