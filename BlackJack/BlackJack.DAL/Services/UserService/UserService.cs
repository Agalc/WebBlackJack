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

    public void InsertUser(UserViewModel user, PlayerType type, int? roundId)
    {
      if (user == null)
      {
        throw new ValidationException("Пользователь не найден", "");
      }
      var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CardViewModel, Card>()).CreateMapper();
      List<Card> cards = mapper.Map<IEnumerable<CardViewModel>, List<Card>>(user.Cards);

      User newUser = new User
      {
        Id = user.Id,
        Name = user.Name,
        Score = user.Score,
        Cards = cards,
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

      var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Card, CardViewModel>()).CreateMapper();
      var cards =  mapper.Map<IEnumerable<Card>, List<CardViewModel>>(wantedUser.Cards);

      return new UserViewModel()
      {
        Id = wantedUser.Id,
        Name = wantedUser.Name,
        Cards = cards,
        Score = wantedUser.Score
      };
    }

    public IEnumerable<UserViewModel> GetAllUsers()
    {
      var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserViewModel>()).CreateMapper();
      return mapper.Map<IEnumerable<User>, List<UserViewModel>>(_database.Users.GetAll());
    }

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
