namespace RealEstateListingApi.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> Create(TEntity entity);
    Task<bool> Delete(Guid id);
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity?> GetById(Guid id);
}