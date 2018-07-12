using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackJack.Core.Enums;

namespace BlackJack.Models
{
  public class CardViewModel
  {
    public Face Face { set; get; }
    public Suit Suit { set; get; }
  }
}