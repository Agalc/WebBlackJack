using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.Core.Enteties;
using BlackJack.Core.Interfaces;

namespace BlackJack.Core.Repositories
{
  public class UserRepository : Repository<User>, IUserRepository
  {
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

    public UserRepository(BjContext context) :
      base(context)
    { }
    public BjContext DataBaseContext => Context as BjContext;
  }
}
