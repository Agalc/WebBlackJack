using System.Collections.Generic;
using BlackJack.Core.Enums;

namespace BlackJack.Core.Services.UserService
{
  public interface IUserService
  {
    void CreateUser(UserViewModel user, PlayerType type);
    void UpdateUser(int? id, UserViewModel editedUser);
    void DeleteUser(int? id);

    UserViewModel GetUser(int? id);
    IEnumerable<UserViewModel> GetAllUsers();

    void Dispose();
  }
}
