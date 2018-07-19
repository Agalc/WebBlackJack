using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.Core.Services.CardService;

namespace BlackJack.Core.Logic
{
  public abstract class Deck
  {
    protected readonly List<CardViewModel> _cards;
    public static byte CardCount { private set; get; }

    protected Deck(List<CardViewModel> cards)
    {
      _cards = cards;
      CreateDeck();
    }

    protected abstract void CreateDeck();

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
      CardCount = (byte)_cards.Count();
    }

    public CardViewModel DrawCard()//достать верхнюю карту из колоды
    {
      CardViewModel takenCard = _cards[_cards.Count - 1];
      _cards.RemoveAt(_cards.Count - 1);
      CardCount = (byte)_cards.Count;
      return takenCard;
    }
  }
}
