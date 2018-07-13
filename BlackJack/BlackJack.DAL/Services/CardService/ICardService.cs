using System.Collections.Generic;
using BlackJack.Core.Enteties;

namespace BlackJack.Core.Services.CardService
{
  public interface ICardService
  {
    void CreateCard(CardViewModel card);
    void UpdateCard(int? id, Card editdCard);
    void DeleteCard(int? id);

    CardViewModel GetCard(int? id);
    IEnumerable<CardViewModel> GetAllCards();

    void Dispose();
  }
}
