using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.Core.Enums;
using BlackJack.Core.Interfaces;
using BlackJack.Core.Services.CardService;


namespace BlackJack.Core.Services.DeckService
{
  public class DeckService
  {
    protected static ICardService _cardService;
    protected readonly List<CardViewModel> _cards;

    public DeckService(IUnitOfWork database)
    {
      _cardService = new CardService.CardService(database);
      _cards = _cardService.GetAllCards().ToList();
      CreateDeck();
    }

    protected void CreateDeck() //Создание колоды
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
      Shuffle();
    }

    public void Shuffle()//перемешивание колоды
    {
      Random rng = new Random();
      int n = _cards.Count;
      while (n > 1)
      {
        n--;
        int k = rng.Next(n + 1);
        CardViewModel card = _cards[k];
        _cards[k] = _cards[n];
        _cards[n] = card;
      }

    }

    public CardViewModel DrawCard()//взять карту
    {
      CardViewModel takenCard = _cards[_cards.Count - 1];
      _cards.RemoveAt(_cards.Count - 1);
      return takenCard;
    }
  }
}
