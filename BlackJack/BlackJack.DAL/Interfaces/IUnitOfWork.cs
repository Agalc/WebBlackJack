using System;
using BlackJack.DAL.Enteties;
using BlackJack.DAL.Repositories;

namespace BlackJack.DAL.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    IUserRepository Users { get; }
    ICardRepository Cards { get; }
    IGameRepository Games { get; }
    IRoundRepository Rounds { get; }

    void Save();
  }
}
