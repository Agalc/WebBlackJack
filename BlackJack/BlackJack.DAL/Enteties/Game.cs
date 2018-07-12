using System;

namespace BlackJack.Core.Enteties
{
  public class Game
  {
    public int? Id { set; get; }
    public DateTime? DateTime { set; get; }

    public int? RoundId { set; get; }
    public Round Round { set; get; }
  }
}
