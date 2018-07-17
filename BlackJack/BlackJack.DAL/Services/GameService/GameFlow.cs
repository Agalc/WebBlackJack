using System.Collections.Generic;
using BlackJack.Core.Services.UserService;

namespace BlackJack.Core.Services.GameService
{
  public class GameFlow
  {
    private const byte maxUsersCount = 7;
    public static List<UserViewModel> _users = new List<UserViewModel>(maxUsersCount);

    public static void Setup(string playerName, byte botCount, string[] botNames)
    {
      _users.Add(new UserViewModel() { Name = playerName });
      for (int i = 0; i < botCount; i++)
      {
        _users.Add(new UserViewModel(){Name = botNames[i]});
      }
      _users.Add(new UserViewModel(){Name = "Dealer"});
    }

    //public static void PlaceCards(Deck deck)//раздача карт в руки
    //{
    //  foreach (var u in _users)
    //  {
    //    //По две карты
    //    u.PutCardInHand(deck.DrawCard());
    //    u.PutCardInHand(deck.DrawCard());
    //  }
    //}

    //public static void CheckScore(User user)//Проверить счет
    //{
    //  if (user.Score > 21)
    //  {
    //    _printer.Print($"{user.Name}'s score is {user.Score} and exceeds 21\n");//Перебор
    //    user.Result = PlayerResult.Busted;
    //  }
    //  if (user.Score == 21)
    //  {
    //    _printer.Print($"{user.Name} has a blackjack!\n");//Блэкджек
    //    user.Result = PlayerResult.BlackJack;
    //  }
    //}

    //public static void SumUp()//Результат матча
    //{
    //  //Если у игрока не перебор и у него больше очков чем у дилера, то он победил
    //  //Или же если у игрока не перебор, а у дилера перебор, то он также победил
    //  if (_users[0].Score > _users[_users.Count - 1].Score && _users[0].Result != PlayerResult.Busted ||
    //      _users[0].Result != PlayerResult.Busted && _users[_users.Count - 1].Result == PlayerResult.Busted)
    //  {
    //    _printer.Print($"{_users[0].Name} has won the Dealer");
    //  }
    //  //Если у дилера не перебор и у него больше очков чем у игрока, то он победил
    //  //Если же у игрока пербеор, то он также победил
    //  else if (_users[_users.Count - 1].Result != PlayerResult.Busted && _users[0].Score < _users[_users.Count - 1].Score ||
    //           _users[0].Result == PlayerResult.Busted)
    //  {
    //    _printer.Print($"Dealer has won the player {_users[0].Name}");
    //  }

    //  else if (_users[0].Score == _users[_users.Count - 1].Score)
    //  {
    //    _printer.Print("Push");
    //  }
    //}

    //public static void PrintStats()//Вывод счета и карт в руке каждого игрока
    //{
    //  foreach (var u in _users)
    //  {
    //    Console.ForegroundColor = ConsoleColor.Cyan;
    //    _printer.Print(u.ToString());
    //    Console.ForegroundColor = ConsoleColor.Red;
    //    CheckScore(u);
    //  }
    //}

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
