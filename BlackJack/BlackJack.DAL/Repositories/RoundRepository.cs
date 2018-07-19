using BlackJack.Core.Enteties;
using BlackJack.Core.Interfaces;

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
