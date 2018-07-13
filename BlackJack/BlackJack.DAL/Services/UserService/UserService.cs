using System.Collections.Generic;
using AutoMapper;
using BlackJack.Core.Enteties;
using BlackJack.Core.Enums;
using BlackJack.Core.Infrastructure;
using BlackJack.Core.Interfaces;
using BlackJack.Core.Services.CardService;

namespace BlackJack.Core.Services.UserService
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
        Cards = CardConverter.ConvertCardVMToCard(editedUser.Cards),
        Id = editedUser.Id,
        Name = editedUser.Name
      };
      _database.Users.Edit((int)id, wantedUser);
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
    }

    public void CreateUser(UserViewModel user, PlayerType type, int? roundId)
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
        Cards = CardConverter.ConvertCardVMToCard(user.Cards),
        Type = type,
        RoundId = roundId
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
        Cards = CardConverter.ConvertCardToCardVM(wantedUser.Cards),
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

    //GameLogic
    public void PutCardInHand(CardViewModel card, UserViewModel user)//Добавить карту в руку
    {
      user.Cards.Add(card);//Добавить карту в руку
      //Если добавляем туз и получается перебор, то туз будет стоить 1 очко
      if (card.Face == Face.Ace && user.Score + 11 > 21)
      {
        user.Cards[user.Cards.Count - 1].Value = 1;
        user.Score += 1;
      }
      //Иначе просто добавляем значение к счету
      else
      {
        user.Score += card.Value;
      }
    }

    public void Dispose()
    {
      _database.Dispose();
    }
  }
}