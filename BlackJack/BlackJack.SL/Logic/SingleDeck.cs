using System;
using System.Collections.Generic;
using BlackJack.DAL.Enums;
using BlackJack.SL.Services.CardService;

namespace BlackJack.SL.Logic
{
  public class SingleDeck : Deck
  {
    public SingleDeck(List<CardViewModel> cards) :
      base(cards)
    { }

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
