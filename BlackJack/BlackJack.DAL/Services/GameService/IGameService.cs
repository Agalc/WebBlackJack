using System.Collections.Generic;

namespace BlackJack.Core.Services.GameService
{
  interface IGameService
  {
    void CreateGame(GameViewModel game);
    void UpdateGame(int? id);
    void DeleteGame(int? id);

    GameViewModel GetGame(int? id);
    IEnumerable<GameViewModel> GetAllGames();

    void Dispose();
  }
}
