using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Domin.Repositories.contract;
// This Is A Generic Repository Interface That Contains The Basic CRUD Operations
public interface IGenericRepository<T, Tkey> where T : class where Tkey : IEquatable<Tkey>
{
    // This Is GRUD Operations Methods   
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Tkey id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Tkey id);
}
