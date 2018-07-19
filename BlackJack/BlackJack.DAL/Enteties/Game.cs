using System;
using System.Collections.Generic;

namespace BlackJack.Core.Enteties
{
  public class Game
  {
    public int? Id { set; get; }
    public DateTime? DateTime { set; get; }

    //FK
    public List<Round> Rounds { set; get; }

    public Game()
    {
      Rounds = new List<Round>();
    }
  }
}