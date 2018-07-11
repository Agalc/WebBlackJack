using System.Collections.Generic;
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

    public IEnumerable<User> GetUserWithCards()
    {
      return new List<User>();
    }
    public UserRepository(BjContext context) :
      base(context)
    { }
    public BjContext BjContext => Context as BjContext;
  }
}
