using System;
using System.Collections.Generic;
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