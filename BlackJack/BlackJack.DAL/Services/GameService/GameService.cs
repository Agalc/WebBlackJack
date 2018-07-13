using System.Collections.Generic;
using AutoMapper;
using BlackJack.Core.Enteties;
using BlackJack.Core.Infrastructure;
using BlackJack.Core.Interfaces;

namespace BlackJack.Core.Services.GameService
{
  class GameService:IGameService
  {
    private readonly IUnitOfWork _database;

    public GameService(IUnitOfWork unitOfWork) => _database = unitOfWork;

    //CRUD
    public void DeleteGame(int? id)
    {
      if (id == null)
      {
        throw new ValidationException("Не установлено id игры", "DeleteGame");
      }

    }

    public void UpdateGame(int? id)
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
