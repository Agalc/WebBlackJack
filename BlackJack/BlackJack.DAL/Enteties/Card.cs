using System.Collections.Generic;
using BlackJack.Core.Enums;

namespace BlackJack.Core.Enteties
{
  public class Card
  {
    public int? Id { set; get; }

    public Face Face { set; get; }
    public Suit Suit { set; get; }

    //FK
    public ICollection<User> Users { get; set; }
    public Card()
    {
      Users = new List<User>();
    }
  }
}