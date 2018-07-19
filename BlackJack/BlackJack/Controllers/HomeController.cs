using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BlackJack.Core;
using BlackJack.Core.Enteties;
using BlackJack.Core.Enums;
using BlackJack.Core.Infrastructure;
using BlackJack.Core.Interfaces;
using BlackJack.Core.Repositories;
using BlackJack.Core.Services.GameService;
using BlackJack.Core.Services.UserService;

namespace BlackJack.Controllers
{
  public class HomeController : Controller
  {
    private const string ConnectionString = "Default";
    static readonly BjContext _context = new BjContext(ConnectionString);
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public HomeController()
    {
      _unitOfWork = new UnitOfWork(_context);
    }

    public ActionResult Index()
    {
      //var model = _unitOfWork.Users.GetAll();
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
      return View();
    }

    [HttpGet]
    public ActionResult Game()
    {
      IGameService gameService = new GameService(_unitOfWork);
      var newGame = new GameViewModel { DateTime = DateTime.Now };
      int gameId;
      try
      {
        gameId = gameService.GetIdOfLastGame();
      }
      catch (ValidationException e)
      {
        Console.WriteLine(e);
        throw;
      }
      finally
      {
        gameId = 1;
        newGame.Id = gameId;
      }

      //gameService.CreateGame(newGame);

      return View();
    }

    [HttpPost]
    public ActionResult Game(List<UserViewModel> users)
    {

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