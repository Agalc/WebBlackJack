using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
    public BjContext DataBaseContext => Context as BjContext;

    public IEnumerable<Card> GetCardsOfUser(int? id)
    {
      if (id == null)
      {
        throw new NullReferenceException();
      }

      return new List<Card>();
    }
  }
}
