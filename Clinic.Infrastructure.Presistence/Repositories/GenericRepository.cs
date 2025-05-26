using Clinic.Core.Domin.Repositories.contract;
using Clinic.Infrastructure.Presistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Presistence.Repositories;
// This Is A Generic Repository Class That Implements The IGenericRepository Interface
public class GenericRepository<T, Tkey>:IGenericRepository<T,Tkey> where T : class where Tkey : IEquatable<Tkey>
{
    private readonly ApplicationContext _context;

    public GenericRepository(ApplicationContext context)
    {
        _context = context;
    }
    //----------------------------------------------------------------------------

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Tkey id)
    {
       return await _context.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
         await _context.Set<T>().AddAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Tkey id)
    {
        var entity = await GetByIdAsync(id);
        if(entity != null)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
