using System;
using BlackJack.DAL.Enteties;

namespace BlackJack.DAL.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    IRepository<User> Users { get; }
    IRepository<Card> Cards { get; }
    IRepository<Game> Games { get; }
    IRepository<Round> Rounds { get; }

    void Save();
  }
}
