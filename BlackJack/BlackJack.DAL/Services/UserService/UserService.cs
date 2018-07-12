using System.Collections.Generic;
using AutoMapper;
using BlackJack.Core.Enteties;
using BlackJack.Core.Enums;
using BlackJack.Core.Infrastructure;
using BlackJack.Core.Interfaces;

namespace BlackJack.Core.Services.UserService
{
  public class UserService : IUserService
  {
    private readonly IUnitOfWork _database;

    public UserService(IUnitOfWork uow) => _database = uow;

    public void InsertUser(UserViewModel user, PlayerType type, int? roundId)
    {
      if (user == null)
      {
        throw new ValidationException("Пользователь не найден", "");
      }

      User newUser = new User
      {
        Id = user.Id,
        Name = user.Name,
        Score = user.Score,
        Cards = user.Cards,
        Type = type,
        RoundId = roundId
      };
      _database.Users.Add(newUser);
      _database.Save();
    }

    public UserViewModel GetUser(int? id)
    {
      if (id == null)
        throw new ValidationException("Не установлено id пользователя", "");

      var wantedUser = _database.Users.Get(id.Value);
      if (wantedUser == null)
        throw new ValidationException("Пользователь не найден", "");

      return new UserViewModel()
      {
        Id = wantedUser.Id,
        Name = wantedUser.Name,
        Cards = wantedUser.Cards,
        Score = wantedUser.Score
      };
    }

    public IEnumerable<UserViewModel> GetAllUsers()
    {
      var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserViewModel>()).CreateMapper();
      return mapper.Map<IEnumerable<User>, List<UserViewModel>>(_database.Users.GetAll());
    }

    public void Dispose()
    {
      _database.Dispose();
    }
  }
}
