using System.Collections.Generic;
using BlackJack.Core.Enums;
using BlackJack.Core.Services.CardService;

namespace BlackJack.Core.Services.UserService
{
  public class UserViewModel
  {
    public int? Id { set; get; }
    public string Name { set; get; }
    public int? Score { set; get; }
    public List<CardViewModel> Cards { set; get; } = new List<CardViewModel>();

    public PlayerResult Result { set; get; }
  }
}