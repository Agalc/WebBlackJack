using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.DAL.Enteties;
using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.Repositories
{
  public class CardRepository : IRepository<Card>
  {
    private readonly BjContext _context;

    public CardRepository(BjContext context)
    {
      _context = context;
    }

    public IEnumerable<Card> GetAll()
    {
      return _context.Cards;
    }

    public Card GetById(int id)
    {
      return _context.Cards.Find(id);
    }

    public void Create(Card card)
    {
      _context.Cards.Add(card);
    }

    public void Update(Card card)
    {
      _context.Entry(card).State = EntityState.Modified;
    }
    public IEnumerable<Card> Find(Func<Card, Boolean> predicate)
    {
      return _context.Cards.Where(predicate).ToList();
    }
    public void Delete(int id)
    {
      Card card = _context.Cards.Find(id);
      if (card != null)
        _context.Cards.Remove(card);
    }
  }
}
