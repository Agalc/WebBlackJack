using System.Collections.Generic;
using AutoMapper;
using BlackJack.Core.Enteties;
using BlackJack.Core.Infrastructure;
using BlackJack.Core.Interfaces;
using BlackJack.Core.Logic;

namespace BlackJack.Core.Services.GameService
{
  public class GameService : IGameService
  {
    private readonly IUnitOfWork _database;
    
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
    public void StartTheGame()
    {
    }

    public GameService(IUnitOfWork unitOfWork) => _database = unitOfWork;

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

      Game newGame = new Game
      {
        Id = game.Id,
        DateTime = game.DateTime
      };
      _database.Games.Add(newGame);
      _database.Save();
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
