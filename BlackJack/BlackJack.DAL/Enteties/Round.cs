using System.Collections.Generic;

namespace BlackJack.DAL.Enteties
{
  public class Round
  {
    public int? Id { set; get; }
    public int? WinnerId { set; get; }

    //FK
    public int? GameId { set; get; }
    public Game Game { set; get; }
    public List<User> Users { set; get; }

    public Round()
    {
      Users = new List<User>();
    }   
  }
}