using System.Collections.Generic;

namespace BlackJack.Core.Enteties
{
  public class Round
  {
    public int? Id { set; get; }
    public int? WinnerId { set; get; }

    public ICollection<User> Users { set; get; }
    public ICollection<Game> Games { set; get; }

    public Round()
    {
      Users = new List<User>();
      Games = new List<Game>();
    }   
  }
}
