using BlackJack.DAL.Enteties;
using BlackJack.DAL.Interfaces;

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
