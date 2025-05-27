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
    private readonly DbSet<T> _dbSet;
    public GenericRepository(ApplicationContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    //----------------------------------------------------------------------------

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet
            .Where(e => EF.Property<bool>(e,"IsDeleted") == false)
            .ToListAsync();
    }
    public async Task<IEnumerable<T>> GetDeletedOnlyAsync()
    {
        return await _dbSet
            .Where(e => EF.Property<bool>(e,"IsDeleted") == true)
            .ToListAsync();
    }
    public async Task<IEnumerable<T>> GetAllIncludingDeletedAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<T?> GetByIdAsync(Tkey id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        
    }

    public async Task SoftDeleteAsync(Tkey id)
    {
        var entity = await _dbSet.FindAsync(id);
        if(entity == null)
            return;

        var isDeletedProp = typeof(T).GetProperty("IsDeleted");
        if(isDeletedProp != null && isDeletedProp.PropertyType == typeof(bool))
        {
            isDeletedProp.SetValue(entity,true);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }

    public async Task HardDeleteAsync(Tkey id)
    {
        var entity = await _dbSet.FindAsync(id);
        if(entity == null)
            return;
        _dbSet.Remove(entity);
    }

    public async Task RestoreByIdAsync(Tkey id)
    {
        var entity = await _dbSet.FindAsync(id);
        if(entity == null)
            return;

        var isDeletedProp = typeof(T).GetProperty("IsDeleted");
        if(isDeletedProp != null && isDeletedProp.PropertyType == typeof(bool))
        {
            isDeletedProp.SetValue(entity,false);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
