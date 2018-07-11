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
    public IEnumerable<User> GetAllUsersWithCards()
    {
      return new List<User>();
    }

    public IEnumerable<User> GetUserWithCards(int? id)
    {
      if (id == null)
      {
        throw new NullReferenceException();
      }
      return DataBaseContext.Users
        .Where(i => i.Id == id)
        .Include(c => c.Cards)
        .ToList(); ;
    }

    public UserRepository(BjContext context) :
      base(context)
    { }
    public BjContext DataBaseContext => Context as BjContext;
  }
}
