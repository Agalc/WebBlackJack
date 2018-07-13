using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.Core.Interfaces;
using BlackJack.Core.Services.CardService;


namespace BlackJack.Core.Services.DeckService
{
  public abstract class DeckService
  {
    protected static IUnitOfWork _unitOfWork;
    protected readonly List<CardViewModel> _cards;
    public static byte  CardCount { private set; get; }

    protected DeckService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
      _cards = CardConverter.ConvertCardToCardVM(_unitOfWork.Cards.GetAll().ToList());
      CreateDeck();
    }

    public abstract void CreateDeck();

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
