using System.Collections.Generic;

namespace BlackJack.Core.Services.CardService
{
  public interface ICardService
  {
    void InsertCard(CardViewModel card);
    void DeleteCard(int? id);
    void UpdateCard(int? id);
    CardViewModel GetCard(int? id);
    IEnumerable<CardViewModel> GetAllCards();

    void Dispose();
  }
}
