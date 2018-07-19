using System.Collections.Generic;
using BlackJack.Core.Enums;

namespace BlackJack.Core.Enteties
{
  public class Round
  {
    public int? Id { set; get; }
    public int? WinnerId { set; get; }

    //FK
    public List<User> Users { set; get; }
    public List<Game> Games { set; get; }
    public Round()
    {
      Users = new List<User>();
      Games = new List<Game>();
    }   
  }
}