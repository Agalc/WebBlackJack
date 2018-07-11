using System.Collections.Generic;
using BlackJack.DAL.Enteties;

namespace BlackJack.DAL.Interfaces
{
  public interface ICardRepository:IRepository<Card>
  {
    IEnumerable<Card> GetCardsOfUser(int? id);
  }
}
