using BlackJack.DAL.Enteties;
using BlackJack.DAL.Interfaces;


namespace BlackJack.DAL.Repositories
{
  public class GameRepository : Repository<Game>, IGameRepository
  {
    public GameRepository(BjContext context) :
      base(context)
    {

    }
  }
}
