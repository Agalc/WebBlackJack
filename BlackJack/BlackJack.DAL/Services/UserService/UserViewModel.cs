using System.Collections.Generic;
using BlackJack.Core.Enums;
using BlackJack.Core.Services.CardService;
using BlackJack.Core.Services.GameService;

namespace BlackJack.Core.Services.UserService
{
  public class UserViewModel
  {
    public int? Id { set; get; }
    public string Name { set; get; }
    public int? Score { set; get; }
    public List<CardViewModel> Cards { set; get; } = new List<CardViewModel>();
    public List<RoundViewModel> Rounds { set; get; } = new List<RoundViewModel>();

    public PlayerResult Result { set; get; }
  }
}