using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.Repositories
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    protected readonly DbContext Context;

    public Repository(DbContext context)
    {
      Context = context;
    }

    public IEnumerable<TEntity> GetAll()
    {
      return Context.Set<TEntity>().ToList();
    }

    public TEntity Get(int id)
    {
      return Context.Set<TEntity>().Find(id);
    }

    public void Add(TEntity entity)
    {
      Context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
      Context.Entry(entity).State = EntityState.Modified;
    }

    public IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate)
    {
      return Context.Set<TEntity>().Where(predicate).ToList();
    }

    public void Remove(int id)
    {
      TEntity entity = Context.Set<TEntity>().Find(id);
      if (entity != null)
        Context.Set<TEntity>().Remove(entity);
    }
  }
}
