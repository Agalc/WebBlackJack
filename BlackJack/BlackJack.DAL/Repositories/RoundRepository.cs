using BlackJack.DAL.Enteties;

namespace BlackJack.DAL.Repositories
{
  public class RoundRepository : Repository<Round>
  {
    RoundRepository(BjContext context) :
      base(context)
    {

    }
  }
}
