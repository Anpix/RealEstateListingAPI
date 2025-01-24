using RealEstateListingApi.Models;
using RealEstateListingApi.Repositories;

namespace RealEstateListingApi.Services;

public class ListingService : IListingService
{
    private readonly IListingRepository _repository;

    public ListingService(IListingRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Listing>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Listing?> GetById(string id)
    {
        return await _repository.GetById(id);
    }

    public async Task<Listing?> Create(Listing listing)
    {
        return await _repository.Create(listing);
    }

    public async Task<Listing?> Update(Listing listing)
    {
        var existingListing = await _repository.GetById(listing.Id);
        if (existingListing == null)
            return null;

        existingListing.Title = listing.Title;
        existingListing.Price = listing.Price;
        existingListing.Description = listing.Description;

        var result = await _repository.SaveChanges();

        return existingListing;
    }

    public async Task<bool> Delete(string id)
    {
        await _repository.Delete(id);
        return true;
    }

}
