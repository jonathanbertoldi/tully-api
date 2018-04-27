using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tully.Core.Models;

namespace Tully.Data.Repositories.Implementations
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
  {
    private Context _context;

    public Repository(Context context)
    {
      _context = context;
    }

    public IQueryable<TEntity> GetAll() => 
      _context
        .Set<TEntity>()
        .Where(a => !a.DeletedAt.HasValue);

    public async Task<TEntity> GetById(Guid id) => 
      await _context
        .Set<TEntity>()
        .FirstOrDefaultAsync(a => a.Id == id);

    public async Task Create(TEntity entity) => 
      await _context
        .AddAsync(entity);

    public async Task Delete(Guid id)
    {
      var entity = await _context
        .Set<TEntity>()
        .Where(a => !a.DeletedAt.HasValue)
        .FirstOrDefaultAsync(a => a.Id == id);

      entity.DeletedAt = DateTime.Now;
    }

    public async Task<bool> Commit() => 
      await _context.SaveChangesAsync() > 0;
  }
}