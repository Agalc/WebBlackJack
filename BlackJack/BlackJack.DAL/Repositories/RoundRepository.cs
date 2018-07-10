using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.DAL.Enteties;
using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.Repositories
{
  public class RoundRepository : IRepository<Round>
  {
    private readonly BjContext _context;

    public RoundRepository(BjContext context)
    {
      _context = context;
    }

    public IEnumerable<Round> GetAll()
    {
      return _context.Rounds;
    }

    public Round GetById(int id)
    {
      return _context.Rounds.Find(id);
    }

    public void Create(Round round)
    {
      _context.Rounds.Add(round);
    }

    public void Update(Round round)
    {
      _context.Entry(round).State = EntityState.Modified;
    }
    public IEnumerable<Round> Find(Func<Round, Boolean> predicate)
    {
      return _context.Rounds.Where(predicate).ToList();
    }
    public void Delete(int id)
    {
      Round round = _context.Rounds.Find(id);
      if (round != null)
        _context.Rounds.Remove(round);
    }
  }
}
