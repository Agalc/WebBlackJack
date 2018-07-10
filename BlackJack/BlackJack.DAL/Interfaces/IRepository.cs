﻿using System;
using System.Collections.Generic;

namespace BlackJack.DAL.Interfaces
{
  public interface IRepository<T> where T : class
  {
    IEnumerable<T> GetAll();
    T GetById(int id);
    IEnumerable<T> Find(Func<T, Boolean> predicate);
    void Create(T item);
    void Update(T item);
    void Delete(int id);
  }
}