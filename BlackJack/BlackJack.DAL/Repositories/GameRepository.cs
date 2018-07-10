using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.DAL.Enteties;
using BlackJack.DAL.Interfaces;


namespace BlackJack.DAL.Repositories
{
  public class GameRepository : IRepository<Game>
  {
    private readonly BjContext _context;

    public GameRepository(BjContext context)
    {
      _context = context;
    }

    public IEnumerable<Game> GetAll()
    {
      return _context.Games;
    }

    public Game GetById(int id)
    {
      return _context.Games.Find(id);
    }

    public void Create(Game game)
    {
      _context.Games.Add(game);
    }

    public void Update(Game game)
    {
      _context.Entry(game).State = EntityState.Modified;
    }
    public IEnumerable<Game> Find(Func<Game, Boolean> predicate)
    {
      return _context.Games.Where(predicate).ToList();
    }
    public void Delete(int id)
    {
      Game game = _context.Games.Find(id);
      if (game != null)
        _context.Games.Remove(game);
    }
  }
}
