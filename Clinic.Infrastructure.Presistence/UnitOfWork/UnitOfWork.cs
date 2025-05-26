using Clinic.Core.Domin.Repositories.contract;
using Clinic.Core.Domin.UnitOfWork.Contract;
using Clinic.Infrastructure.Presistence.Data;
using Clinic.Infrastructure.Presistence.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Presistence.UnitOfWork;
// This Is A UnitOfWork Class That Implements The IUnitOfWork Interface
public class UnitOfWork:IUnitOfWork
{
    private readonly ConcurrentDictionary<string,object> _repositories;
    private readonly ApplicationContext _context;
    public UnitOfWork(ApplicationContext context)
    {
        _repositories = new ConcurrentDictionary<string,object>();
        _context = context;
    }
    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
    public async ValueTask DisposeAsync() => await _context.DisposeAsync();

    // This Method Is Used To Get A Generic Repository For A Specific Entity Type
    public IGenericRepository<T,Tkey> GetRepository<T, Tkey>()
        where T : class
        where Tkey : IEquatable<Tkey>
    {
        // Check If The Repository Already Exists In The Dictionary Or Not
        var key = typeof(T).FullName!;
        return (IGenericRepository<T,Tkey>) _repositories.GetOrAdd(key,_ =>
            new GenericRepository<T,Tkey>(_context));
    }
}
