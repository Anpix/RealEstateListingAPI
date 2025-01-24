using Microsoft.EntityFrameworkCore;
using RealEstateListingApi.Data;

namespace RealEstateListingApi.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    internal ApplicationDbContext context;
    internal DbSet<TEntity> dbSet;

    public Repository(ApplicationDbContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        return await dbSet.ToListAsync();
    }

    public virtual async Task<TEntity?> GetById(Guid id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual async Task<TEntity?> Create(TEntity entity)
    {
        dbSet.Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<bool> Delete(Guid id)
    {
        var entity = await dbSet.FindAsync(id);
        if (entity == null)
            return false;

        dbSet.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

}
