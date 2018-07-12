using System.Collections.Generic;
using BlackJack.Core.Enums;

namespace BlackJack.Core.Services.UserService
{
  public interface IUserService
  {
    void InsertUser(UserViewModel user, PlayerType type, int? roundId);
    UserViewModel GetUser(int? id);
    IEnumerable<UserViewModel> GetAllUsers();
    void Dispose();
  }
}
