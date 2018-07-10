using System;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Repositories;

namespace BlackJack.DAL.Enteties
{
  public class UnitOfWork : IUnitOfWork
  {

    private readonly BjContext _context;
    private UserRepository _userRepository;
    private GameRepository _gameRepository;
    private RoundRepository _roundRepository;
    private CardRepository _cardRepository;

    public UnitOfWork(string connectionString)
    {
      _context = new BjContext(connectionString);
    }

    public IRepository<User> Users
    {
      get
      {
        if (_userRepository == null)
          _userRepository = new UserRepository(_context);
        return _userRepository;
      }
    }

    public IRepository<Game> Games
    {
      get
      {
        if (_gameRepository == null)
          _gameRepository = new GameRepository(_context);
        return _gameRepository;
      }
    }

    public IRepository<Round> Rounds
    {
      get
      {
        if (_roundRepository == null)
          _roundRepository = new RoundRepository(_context);
        return _roundRepository;
      }
    }

    public IRepository<Card> Cards
    {
      get
      {
        if (_cardRepository == null)
          _cardRepository = new CardRepository(_context);
        return _cardRepository;
      }
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
