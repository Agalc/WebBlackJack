using System.Collections.Generic;
using BlackJack.DAL.Enums;
using BlackJack.SL.Services.CardService;
using BlackJack.SL.Services.UserService;

namespace BlackJack.SL.Logic
{
  internal static class GameLogic
  {
    private const byte maxUsersCount = 7;
    private static readonly List<UserViewModel> _users = new List<UserViewModel>(maxUsersCount);

    public static void Setup(string playerName, string[] botNames)//
    {
      _users.Add(new UserViewModel() { Name = playerName });
      foreach (var n in botNames)
      {
        _users.Add(new UserViewModel() { Name = n });
      }
      _users.Add(new UserViewModel() { Name = "Dealer" });
    }

    private static void PutCardInHand(CardViewModel card, UserViewModel user)//Добавить карту в руку
    {
      user.Cards.Add(card);//Добавить карту в руку
      //Если добавляем туз и получается перебор, то туз будет стоить 1 очко
      if (card.Face == Face.Ace && user.Score + 11 > 21)
      {
        user.Cards[user.Cards.Count - 1].Value = 1;
        user.Score += 1;
      }
      //Иначе просто добавляем значение к счету
      else
      {
        user.Score += card.Value;
      }
    }

    public static void PlaceCards(Deck deck)//раздача карт в руки
    {
      foreach (var u in _users)
      {
        //По две карты
        PutCardInHand(deck.DrawCard(), u);
        PutCardInHand(deck.DrawCard(), u);
      }
    }

    public static void CheckScore(UserViewModel user)//Проверить счет
    {
      if (user.Score > 21)
      {
        //_printer.Print($"{user.Name}'s score is {user.Score} and exceeds 21\n");//Перебор
        user.Result = PlayerResult.Busted;
      }
      if (user.Score == 21)
      {
        //_printer.Print($"{user.Name} has a blackjack!\n");//Блэкджек
        user.Result = PlayerResult.BlackJack;
      }
    }

    public static void SumUp()//Результат матча
    {
      //Если у игрока не перебор и у него больше очков чем у дилера, то он победил
      //Или же если у игрока не перебор, а у дилера перебор, то он также победил
      if (_users[0].Score > _users[_users.Count - 1].Score && _users[0].Result != PlayerResult.Busted ||
          _users[0].Result != PlayerResult.Busted && _users[_users.Count - 1].Result == PlayerResult.Busted)
      {
        //_printer.Print($"{_users[0].Name} has won the Dealer");
      }
      //Если у дилера не перебор и у него больше очков чем у игрока, то он победил
      //Если же у игрока пербеор, то он также победил
      else if (_users[_users.Count - 1].Result != PlayerResult.Busted && _users[0].Score < _users[_users.Count - 1].Score ||
               _users[0].Result == PlayerResult.Busted)
      {
        //_printer.Print($"Dealer has won the player {_users[0].Name}");
      }

      else if (_users[0].Score == _users[_users.Count - 1].Score)
      {
        //_printer.Print("Push");
      }
    }

    //public static void Play()//ход игры
    //{
    //  //Новая колода
    //  Deck deck = new SingleDeck();
    //  //Регистрация и добавление ботов
    //  Setup();
    //  //Раздача
    //  PlaceCards(deck);
    //  _printer.Print(_users[0].ToString());
    //  //Добор карт
    //  foreach (var u in _users)
    //    u.DecideWhetherTakeCard(deck);
    //  //Вывод карт каждого игрока
    //  PrintStats();

    //  SumUp();//Итог матча
    //  _printer.Wait();
  }
}
