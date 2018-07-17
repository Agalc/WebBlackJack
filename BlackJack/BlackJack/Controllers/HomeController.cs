using System.Web.Mvc;
using BlackJack.Core;
using BlackJack.Core.Enteties;
using BlackJack.Core.Enums;
using BlackJack.Core.Interfaces;
using BlackJack.Core.Repositories;
using BlackJack.Core.Services.DeckService;
using BlackJack.Core.Services.UserService;

namespace BlackJack.Controllers
{
  public class HomeController : Controller
  {
    private const string ConnectionString = "Default";
    static readonly BjContext _context = new BjContext(ConnectionString);
    private readonly IUnitOfWork _unitOfWork;

    public HomeController()
    {
      _unitOfWork = new UnitOfWork(_context);
    }

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult HistoryOfGames()//show all games
    {
      IUserService userService = new UserService(_unitOfWork);
      ViewBag.User = userService.GetAllUsers();
      return View();
    }

    [HttpGet]
    public ActionResult AddUser()
    {
      return View();
    }

    [HttpPost]
    public ActionResult AddUser(UserViewModel newUser)
    {
      IUserService userService = new UserService(_unitOfWork);
      userService.CreateUser(newUser, PlayerType.Player);
      _unitOfWork.Save();
      return View();
    }


    public ActionResult Game()
    {
      new SingleDeckService(_unitOfWork);

      return View();
    }

    [HttpGet]
    public ActionResult Hand(int id)
    {
      User u = _unitOfWork.Users.GetCardsOfUser(id);
      return View(u);
    }
  }
}