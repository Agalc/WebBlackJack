using System.Collections.Generic;

namespace BlackJack.DAL.Enteties
{
  public class Round
  {
    public int? Id { set; get; }
    public string Winner { set; get; }

    public ICollection<User> Users { set; get; }
    public ICollection<Game> Games { set; get; }

    public Round()
    {
      Users = new List<User>();
      Games = new List<Game>();
    }   
  }
}
