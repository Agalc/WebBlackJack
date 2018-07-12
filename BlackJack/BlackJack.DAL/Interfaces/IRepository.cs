using System;
using System.Collections.Generic;

namespace BlackJack.Core.Interfaces
{
  public interface IRepository<TEntity> where TEntity : class
  {
    TEntity Get(int id);
    IEnumerable<TEntity> GetAll();    
    IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate);

    void Add(TEntity item);
    void Remove(int id);
  }
}
