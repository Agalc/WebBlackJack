using System.Collections.Generic;
using BlackJack.Core.Enteties;

namespace BlackJack.Core.Interfaces
{
  public interface ICardRepository:IRepository<Card>
  {
    IEnumerable<Card> GetCardsOfUser(int? id);
  }
}
