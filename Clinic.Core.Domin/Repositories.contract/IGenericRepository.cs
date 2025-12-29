namespace Clinic.Core.Domin.Repositories.contract;
// This Is A Generic Repository Interface That Contains The Basic CRUD Operations
public interface IGenericRepository<T, Tkey> where T : class where Tkey : IEquatable<Tkey>
{
    // This Is GRUD Operations Methods   
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetDeletedOnlyAsync();
    Task<IEnumerable<T>> GetAllIncludingDeletedAsync();
    Task<T?> GetByIdAsync(Tkey id);
    Task AddAsync(T entity);
    void UpdateAsync(T entity);
    Task SoftDeleteAsync(Tkey id);
    Task HardDeleteAsync(Tkey id);
    Task RestoreByIdAsync(Tkey id);
}
