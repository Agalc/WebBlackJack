using System;
using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    public ICardRepository Cards { get; }
    public IGameRepository Games { get; }
    public IRoundRepository Rounds { get; }
    public IUserRepository Users { get; }

    private readonly BjContext _context;

    public UnitOfWork(BjContext context)
    {
      _context = context;

      Cards = new CardRepository(_context);
      Games = new GameRepository(_context);
      Rounds = new RoundRepository(_context);
      Users = new UserRepository(_context);
    }

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
