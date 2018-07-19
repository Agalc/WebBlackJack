using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BlackJack.DAL.Enteties;
using BlackJack.DAL.Interfaces;
using BlackJack.SL.Infrastructure;
using BlackJack.SL.Logic;
using BlackJack.SL.Services.CardService;

namespace BlackJack.SL.Services.GameService
{
  public class GameService : IGameService
  {
    private readonly IUnitOfWork _database;
    public GameService(IUnitOfWork unitOfWork) => _database = unitOfWork;

    public void CreateDeck()
    {
      Deck deck = new SingleDeck(CardConverter.ConvertCardToCardVm(_database.Cards.GetAll().ToList()));
    }

    public void StartTheGame()
    {
    }


    //public static void Play()//ход игры
    //{
    //  //Регистрация и добавление ботов
    //  Setup();
    //  //Раздача
    //  PlaceCards(deck);
    //  _printer.Print(_users[0].ToString());
    //  //Добор карт
    //  foreach (var u in _users)
    //    u.DecideWhetherTakeCard(deck);
    //  //Вывод карт каждого игрока
    //  PrintStats();

    //  SumUp();//Итог матча


    //CRUD
    public void DeleteGame(int? id)
    {
      if (id == null)
      {
        throw new ValidationException("Не установлено id игры", "DeleteGame");
      }
      var wantedGame = _database.Games.Get(id.Value);
      if (wantedGame == null)
      {
        throw new ValidationException("Игра не найдена", "DeleteUser");
      }
      _database.Games.Remove(id.Value);
      _database.Save();
    }

    public void UpdateGame(int? id, GameViewModel editedGame)
    {
      if (id == null)
      {
        throw new ValidationException("Не установлено id игры", "UpdateGame");
      }

      var wantedGame = _database.Games.Get(id.Value);
      if (wantedGame == null)
      {
        throw new ValidationException("Игра не найдена", "UpdateGame");
      }
      wantedGame = new Game
      {
        Id = editedGame.Id,
        DateTime = editedGame.DateTime
      };
      _database.Games.Edit((int)id, wantedGame);
      _database.Save();
    }

    public void CreateGame(GameViewModel game)
    {
      if (game == null)
      {
        throw new ValidationException("Игра не найдена", "CreateGame");
      }

      var newGame = new Game { DateTime = game.DateTime };
      _database.Games.Add(newGame);
      _database.Save();
    }

    public int GetIdOfLastGame()
    {
      var games =_database.Games.GetAll().ToList();
      if (games.Count == 0)
      {
        throw new ValidationException("Игр не найдено", "GetIdOfLastGame");
      }
      int? lastIndex = games[games.Count-1].Id;
      if (lastIndex==null)
      {
        throw new ValidationException("Последняя игра не найдена", "GetIdOfLastGame");
      }
      return lastIndex.Value;
    }

    public GameViewModel GetGame(int? id)
    {
      if (id == null)
      {
        throw new ValidationException("Не установлено id игры", "GetGame");
      }

      var wantedGame = _database.Games.Get(id.Value);
      if (wantedGame == null)
      {
        throw new ValidationException("Игра не найдена", "GetGame");
      }

      return new GameViewModel()
      {
        Id = wantedGame.Id,
        DateTime = wantedGame.DateTime
      };
    }

    public IEnumerable<GameViewModel> GetAllGames()
    {
      var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Game, GameViewModel>()).CreateMapper();
      return mapper.Map<IEnumerable<Game>, List<GameViewModel>>(_database.Games.GetAll());
    }

    public void Dispose()
    {
      _database.Dispose();
    }
  }
}