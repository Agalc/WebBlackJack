using BlackJack.Core.Enteties;

namespace BlackJack.Core.Repositories
{
  public class RoundRepository : Repository<Round>, IRoundRepository
  {
    public RoundRepository(BjContext context) :
      base(context)
    {

    }
  }
}
