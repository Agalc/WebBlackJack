using System.Collections.Generic;
using AutoMapper;
using BlackJack.Core.Enteties;

namespace BlackJack.Core.Services.CardService
{
  public class CardConverter
  {
    //Cards convertation
    public static List<Card> ConvertCardVmToCard(List<CardViewModel> cardsViewModel)//VM - ViewModel
    {
      //from CardViewModel to Card
      var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CardViewModel, Card>()).CreateMapper();
      return mapper.Map<IEnumerable<CardViewModel>, List<Card>>(cardsViewModel);
    }

    public static List<CardViewModel> ConvertCardToCardVm(List<Card> cards)
    {
      //frim Card to ViewModel
      var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Card, CardViewModel>()).CreateMapper();
      return mapper.Map<IEnumerable<Card>, List<CardViewModel>>(cards);
    }
  }
}
