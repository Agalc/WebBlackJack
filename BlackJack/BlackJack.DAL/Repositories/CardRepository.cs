using BlackJack.DAL.Enteties;
using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.Repositories
{
  public class CardRepository : Repository<Card>, ICardRepository
  {
    public CardRepository(BjContext context) :
      base(context)
    {

    }
  }
}
