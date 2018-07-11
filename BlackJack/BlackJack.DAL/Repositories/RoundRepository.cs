using BlackJack.DAL.Enteties;

namespace BlackJack.DAL.Repositories
{
  public class RoundRepository : Repository<Round>, IRoundRepository
  {
    public RoundRepository(BjContext context) :
      base(context)
    {

    }
  }
}
