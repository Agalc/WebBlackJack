using System.Collections.Generic;
using BlackJack.Core.Enteties;
using BlackJack.Core.Enums;

namespace BlackJack.Core.Services.UserService
{
  public class UserViewModel
  {
    public int? Id { set; get; }
    public string Name { set; get; }
    public int? Score { set; get; }
    public PlayerResult Result { set; get; }
    public List<Card> Cards { set; get; } = new List<Card>();
  }
}
