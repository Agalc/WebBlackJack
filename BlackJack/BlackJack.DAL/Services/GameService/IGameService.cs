using System.Collections.Generic;

namespace BlackJack.Core.Services.GameService
{
  public interface IGameService
  {
    void CreateGame(GameViewModel game);
    void UpdateGame(int? id, GameViewModel editedGame);
    void DeleteGame(int? id);
    int GetIdOfLastGame();

    GameViewModel GetGame(int? id);
    IEnumerable<GameViewModel> GetAllGames();

    void Dispose();
  }
}
