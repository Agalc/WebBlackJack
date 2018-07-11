using BlackJack.DAL.Enteties;


namespace BlackJack.DAL.Repositories
{
  public class GameRepository : Repository<Game>
  {
    GameRepository(BjContext context) :
      base(context)
    {

    }
  }
}
