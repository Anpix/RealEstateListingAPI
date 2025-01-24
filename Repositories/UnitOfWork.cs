using RealEstateListingApi.Data;
using RealEstateListingApi.Models;

namespace RealEstateListingApi.Repositories;

public class UnitOfWork : IDisposable, IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IRepository<Listing> _listingRepository;
    private bool disposed = false;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IRepository<Listing> ListingRepository
    {
        get => _listingRepository ??= new Repository<Listing>(_context);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();

    }

    #region Dispose

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed && disposing)
            _context.Dispose();

        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
