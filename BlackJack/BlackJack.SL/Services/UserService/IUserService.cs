using System.Collections.Generic;
using BlackJack.DAL.Enums;

namespace BlackJack.SL.Services.UserService
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
