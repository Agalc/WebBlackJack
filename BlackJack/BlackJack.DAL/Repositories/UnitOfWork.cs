using System;
using BlackJack.Core.Interfaces;

namespace BlackJack.Core.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {

    private readonly BjContext _context;

    public UnitOfWork(string connectionString)
    {
      _context = new BjContext(connectionString);

      Cards = new CardRepository(_context);
      Games = new GameRepository(_context);
      Rounds = new RoundRepository(_context);
      Users = new UserRepository(_context);
    }

    public ICardRepository Cards { private set; get; }
    public IGameRepository Games { private set; get; }
    public IRoundRepository Rounds { private set; get; }
    public IUserRepository Users { private set; get; }

    public void Save()
    {
      _context.SaveChanges();
    }

    private bool _disposed;

    public virtual void Dispose(bool disposing)
    {
      if (!_disposed)
      {
        if (disposing)
        {
          _context.Dispose();
        }
        _disposed = true;
      }
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}
