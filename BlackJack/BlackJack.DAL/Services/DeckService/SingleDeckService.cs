using System;
using System.Collections.Generic;
using BlackJack.Core.Enteties;
using BlackJack.Core.Enums;
using BlackJack.Core.Interfaces;
using BlackJack.Core.Services.CardService;

namespace BlackJack.Core.Services.DeckService
{
  public class SingleDeckService : DeckService
  {
    public SingleDeckService(IUnitOfWork unitOfWork) :
      base(unitOfWork)
    { }

    private void FillTableWithCards(List<CardViewModel> cardsViewModel)
    {
      List<Card> cards = CardConverter.ConvertCardVmToCard(cardsViewModel);
      foreach (var c in cards)
      {
        _unitOfWork.Cards.Add(c);
        _unitOfWork.Save();
      }
    }

    protected override void CreateDeck() //Создание колоды
    {
      for (var i = 0; i < 4; i++)
      {
        for (var j = 0; j < 13; j++)
        {
          // +2 к значению из-за None и отсутствия единицы в колоде, +1 к масти из-за None
          _cards.Add(new CardViewModel() { Face = (Face)j + 1, Suit = (Suit)i + 1, Value = Math.Min(j + 2, 10) });
        }
        _cards[_cards.Count - 1].Value = 11;//для туза задать 11
      }
      //FillTableWithCards(_cards);
      Shuffle();
    }
  }
}
