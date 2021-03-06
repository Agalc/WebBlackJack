﻿using System.Collections.Generic;
using AutoMapper;
using BlackJack.DAL.Enteties;
using BlackJack.DAL.Interfaces;
using BlackJack.SL.Infrastructure;

namespace BlackJack.SL.Services.CardService
{
  public class CardService : ICardService
  {
    private readonly IUnitOfWork _database;

    public CardService(IUnitOfWork unitOfWork) => _database = unitOfWork;


    //CRUD
    public void DeleteCard(int? id)
    {
      if (id == null)
      {
        throw new ValidationException("Не установлено id карты", "DeleteCard");
      }
      var wantedCard = _database.Cards.Get(id.Value);
      if (wantedCard == null)
      {
        throw new ValidationException("Карта не найдена", "DeleteUser");
      }
      _database.Cards.Remove(id.Value);
      _database.Save();
    }

    public void UpdateCard(int? id, Card editedCard)
    {
      if (id == null)
      {
        throw new ValidationException("Не установлено id карты", "UpdateCard");
      }

      var wantedCard = _database.Cards.Get(id.Value);
      if (wantedCard == null)
      {
        throw new ValidationException("Карта не найдена", "UpdateCard");
      }
      wantedCard = new Card
      {
        Face = editedCard.Face,
        Id = editedCard.Id,
        Suit = editedCard.Suit
      };
      _database.Cards.Edit((int)id, wantedCard);
      _database.Save();
    }

    public void CreateCard(CardViewModel card)
    {
      if (card == null)
      {
        throw new ValidationException("Карта не найдена", "CreateCard");
      }

      Card newCard = new Card
      {
        Id = card.Id,
        Face = card.Face,
        Suit = card.Suit
      };
      _database.Cards.Add(newCard);
      _database.Save();
    }

    public CardViewModel GetCard(int? id)
    {
      if (id == null)
      {
        throw new ValidationException("Не установлено id карты", "GetCard");
      }

      var wantedCard = _database.Cards.Get(id.Value);
      if (wantedCard == null)
      {
        throw new ValidationException("Карта не найдена", "GetCard");
      }

      return new CardViewModel()
      {
        Id = wantedCard.Id,
        Face = wantedCard.Face,
        Suit = wantedCard.Suit
      };
    }

    public IEnumerable<CardViewModel> GetAllCards()
    {
      var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Card, CardViewModel>()).CreateMapper();
      return mapper.Map<IEnumerable<Card>, List<CardViewModel>>(_database.Cards.GetAll());
    }

    public void Dispose()
    {
      _database.Dispose();
    }
  }
}
