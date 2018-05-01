using System;
using System.Linq;
using System.Threading.Tasks;
using Tully.Core.Models;

namespace Tully.Core.Data
{
  public interface IRepository<TEntity> where TEntity : class, IEntity
  {
    IQueryable<TEntity> GetAll();

    Task<TEntity> GetById(Guid id);

    Task Create(TEntity entity);

    Task Delete(Guid id);

    Task<bool> Commit();
  }
}