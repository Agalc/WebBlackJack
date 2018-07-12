using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.Core.Enteties;
using BlackJack.Core.Interfaces;

namespace BlackJack.Core.Repositories
{
  public class CardRepository : Repository<Card>, ICardRepository
  {
    public CardRepository(BjContext context) :
      base(context)
    {

    }
    public BjContext DataBaseContext => _context as BjContext;

    public IEnumerable<Card> GetCardsOfUser(int? id)
    {
      if (id == null)
      {
        throw new NullReferenceException();
      }

      User u = DataBaseContext.Users.Find(id);
      return DataBaseContext.Cards
        .Where(o => o.Id == id)
        .ToList();
    }
  }
}