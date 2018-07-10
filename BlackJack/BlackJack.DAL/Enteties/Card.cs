using System.Collections.Generic;
using BlackJack.DAL.Enums;

namespace BlackJack.DAL.Enteties
{
  public class Card
  {
    public int? Id { set; get; }

    public Face Face { set; get; }
    public Suit Suit { set; get; }

    public ICollection<User> Users { get; set; }

    public Card()
    {
      Users = new List<User>();
    }
  }
}
