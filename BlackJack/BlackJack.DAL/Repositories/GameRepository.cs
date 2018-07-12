using BlackJack.Core.Enteties;
using BlackJack.Core.Interfaces;


namespace BlackJack.Core.Repositories
{
  public class GameRepository : Repository<Game>, IGameRepository
  {
    public GameRepository(BjContext context) :
      base(context)
    {

    }
  }
}
