﻿using System.Collections.Generic;
using BlackJack.DAL.Enums;

namespace BlackJack.DAL.Enteties
{
  public class User
  {
    public int? Id { set; get; }
    public string Name { set; get; }
    public int? Score { get; set; }
    public PlayerType Type { get; set; }

    public ICollection<Card> Cards { get; set; }

    public User()
    {
      Cards = new List<Card>();
    }

    public int? RoundId { set; get; }
    public Round Roound { set; get; }
  }
}