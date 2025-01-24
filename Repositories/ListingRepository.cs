using Microsoft.EntityFrameworkCore;
using RealEstateListingApi.Data;
using RealEstateListingApi.Models;

namespace RealEstateListingApi.Repositories;

public class ListingRepository : IListingRepository
{
    private readonly ApplicationDbContext _context;

    public ListingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Listing>> GetAll()
    {
        return await _context.Listings.ToListAsync();
    }

    public async Task<Listing?> GetById(Guid id)
    {
        return await _context.Listings.FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<Listing?> Create(Listing listing)
    {
        _context.Listings.Add(listing);
        await _context.SaveChangesAsync();
        return listing;
    }

    public async Task<Listing?> Update(Listing listing)
    {
        var existingListing = _context.Listings.FirstOrDefault(l => l.Id == listing.Id);
        if (existingListing == null)
            return null;

        existingListing.Title = listing.Title;
        existingListing.Price = listing.Price;
        existingListing.Description = listing.Description;
        await _context.SaveChangesAsync();
        
        return existingListing;
    }

    public async Task<bool> Delete(Guid id)
    {
        var listing = _context.Listings.FirstOrDefault(l => l.Id == id);
        if (listing == null)
            return false;

        _context.Listings.Remove(listing);
        await _context.SaveChangesAsync();

        return true;
    }


    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }
}
