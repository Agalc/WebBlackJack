using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.Repositories
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    protected readonly DbContext _context;

    public Repository(DbContext context) => _context = context;

    public IEnumerable<TEntity> GetAll()
    {
      return _context.Set<TEntity>().ToList();
    }

    public TEntity Get(int id)
    {
      return _context.Set<TEntity>().Find(id);
    }

    public void Add(TEntity entity)
    {
      _context.Set<TEntity>().Add(entity);
    }

    public void Edit(int id, TEntity editedEntity)
    {
      TEntity entity = _context.Set<TEntity>().Find(id);
      _context.Entry(entity).CurrentValues.SetValues(editedEntity);

    }

    public IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate)
    {
      return _context.Set<TEntity>().Where(predicate).ToList();
    }

    public void Remove(int id)
    {
      TEntity entity = _context.Set<TEntity>().Find(id);
      if (entity != null)
        _context.Set<TEntity>().Remove(entity);
    }
  }
}
