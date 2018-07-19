using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.DAL.Enteties;
using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.Repositories
{
  public class UserRepository : Repository<User>, IUserRepository
  {
    public UserRepository(BjContext context) :
      base(context)
    { }

    public BjContext DataBaseContext => _context as BjContext;

    public IEnumerable<User> GetAllUsersWithCards()
    {
      return DataBaseContext.Users
        .Include(c => c.Cards)
        .ToList();
    }

    public User GetCardsOfUser(int? id)
    {
      if (id == null)
      {
        throw new NullReferenceException();
      }
      var u = DataBaseContext.Users
        .Include(c => c.Cards)
        .Single(i => i.Id == id);
      return u;
    }
  }
}
