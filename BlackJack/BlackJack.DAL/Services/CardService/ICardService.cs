using System.Collections.Generic;
using BlackJack.Core.Enteties;

namespace BlackJack.Core.Services.CardService
{
  public interface ICardService
  {
    void InsertCard(CardViewModel card);
    CardViewModel GetCard(int? id);
    IEnumerable<CardViewModel> GetAllCards();
    void Dispose();
  }
}
