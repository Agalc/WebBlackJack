using BlackJack.Core.Enums;

namespace BlackJack.Core.Services.CardService
{
  public class CardViewModel
  {
    public int? Id { set; get; }

    public Face Face { set; get; }
    public Suit Suit { set; get; }
    public int Value { set; get; }
  }
}
