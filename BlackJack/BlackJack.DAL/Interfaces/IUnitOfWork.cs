using System;
using BlackJack.Core.Repositories;
using BlackJack.Core.Enums;

namespace BlackJack.Core.Interfaces
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
