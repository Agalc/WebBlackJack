using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackJack.DAL.Enums;

namespace BlackJack.Models
{
  public class UserViewModel
  {
    public string Name { set; get; }
    public int? Score { get; set; }
    public PlayerType Type { get; set; }
  }
}