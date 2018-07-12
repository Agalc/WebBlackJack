using System.Collections.Generic;
using BlackJack.Core.Enteties;

namespace BlackJack.Core.Interfaces
{
  public interface IUserRepository : IRepository<User>
  {
    IEnumerable<User> GetAllUsersWithCards();
    User GetCardsOfUser(int? id);
  }
}
