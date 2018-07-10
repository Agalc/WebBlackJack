using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.DAL.Enteties;
using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.Repositories
{
  public class UserRepository : IRepository<User>
  {
    private readonly BjContext _context;
    public UserRepository(BjContext context)
    {
      _context = context;
    }

    public IEnumerable<User> GetAll()
    {
      return _context.Users;
    }

    public User GetById(int id)
    {
      return _context.Users.Find(id);
    }

    public void Create(User user)
    {
      _context.Users.Add(user);
    }

    public void Update(User user)
    {
      _context.Entry(user).State = EntityState.Modified;
    }

    public IEnumerable<User> Find(Func<User, Boolean> predicate)
    {
      return _context.Users.Where(predicate).ToList();
    }

    public void Delete(int id)
    {
      User user = _context.Users.Find(id);
      if (user != null)
        _context.Users.Remove(user);
    }
  }
}
