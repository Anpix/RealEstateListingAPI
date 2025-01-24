using RealEstateListingApi.Data;
using RealEstateListingApi.Models;

namespace RealEstateListingApi.Services;

public class ListingService : IListingService
{
    private readonly ApplicationDbContext _context;

    public ListingService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Listing> GetAll()
    {
        return _context.Listings.ToList();
    }

    public Listing? GetById(string id)
    {
        return _context.Listings.FirstOrDefault(l => l.Id == id);
    }

    public Listing Create(Listing listing)
    {
        _context.Listings.Add(listing);
        _context.SaveChanges();
        return listing;
    }

    public Listing? Update(string id, Listing listing)
    {
        var existingListing = _context.Listings.FirstOrDefault(l => l.Id == id);
        if (existingListing == null)
            return null;

        existingListing.Title = listing.Title;
        existingListing.Price = listing.Price;
        existingListing.Description = listing.Description;

        _context.SaveChanges();

        return existingListing;
    }

    public bool Delete(string id)
    {
        var listing = _context.Listings.FirstOrDefault(l => l.Id == id);
        if (listing == null)
            return false;

        _context.Listings.Remove(listing);
        _context.SaveChanges();
        return true;
    }

}
