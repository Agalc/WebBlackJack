using System.Collections.Generic;
using AutoMapper;
using BlackJack.DAL.Enteties;
using BlackJack.DAL.Enums;
using BlackJack.DAL.Interfaces;
using BlackJack.SL.Infrastructure;
using BlackJack.SL.Services.CardService;

namespace BlackJack.SL.Services.UserService
{
  public class UserService : IUserService
  {
    private readonly IUnitOfWork _database;

    public UserService(IUnitOfWork unitOfWork) => _database = unitOfWork;

    //CRUD
    public void UpdateUser(int? id, UserViewModel editedUser)
    {
      if (id == null)
      {
        throw new ValidationException("Не установлен id пользователя", "UpdateUser");
      }

      User wantedUser = _database.Users.Get((int)id);
      if (wantedUser == null)
      {
        throw new ValidationException("Пользователь не найден", "GetUser");
      }

      wantedUser = new User()
      {
        Cards = CardConverter.ConvertCardVmToCard(editedUser.Cards),
        Id = editedUser.Id,
        Name = editedUser.Name
      };
      _database.Users.Edit((int)id, wantedUser);
      _database.Save();
    }

    public void DeleteUser(int? id)
    {
      if (id == null)
      {
        throw new ValidationException("Не установлен id пользователя", "DeleteUser");
      }

      var wantedUser = _database.Users.Get(id.Value);
      if (wantedUser == null)
      {
        throw new ValidationException("Пользователь не найден", "DeleteUser");
      }
      _database.Users.Remove(id.Value);
      _database.Save();
    }

    public void CreateUser(UserViewModel user, PlayerType type)
    {
      if (user == null)
      {
        throw new ValidationException("Пользователь не найден", "CreateUser");
      }

      User newUser = new User
      {
        Id = user.Id,
        Name = user.Name,
        Score = user.Score,
        Cards = CardConverter.ConvertCardVmToCard(user.Cards),
        Type = type,
        //Rounds = user.Rounds
      };
      _database.Users.Add(newUser);
      _database.Save();
    }

    public UserViewModel GetUser(int? id)
    {
      if (id == null)
        throw new ValidationException("Не установлено id пользователя", "GetUser");

      var wantedUser = _database.Users.Get(id.Value);
      if (wantedUser == null)
        throw new ValidationException("Пользователь не найден", "GetUser");

      return new UserViewModel()
      {
        Id = wantedUser.Id,
        Name = wantedUser.Name,
        Cards = CardConverter.ConvertCardToCardVm(wantedUser.Cards),
        Score = wantedUser.Score
      };
    }

    public IEnumerable<UserViewModel> GetAllUsers()
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<User, UserViewModel>()
          .ForMember(destanation => destanation.Cards,
            opts => opts.MapFrom(source => source.Cards));
      });
      //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserViewModel>()).CreateMapper();
      return config.CreateMapper().Map<IEnumerable<User>, List<UserViewModel>>(_database.Users.GetAll());
    }

    public void Dispose()
    {
      _database.Dispose();
    }
  }
}