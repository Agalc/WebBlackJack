using System.Web.Mvc;
using BlackJack.Core.Enteties;
using BlackJack.Core.Interfaces;
using BlackJack.Core.Repositories;

namespace BlackJack.Controllers
{
  public class HomeController : Controller
  {
    private const string ConnectionString = "Default";
    private readonly IUnitOfWork _unitOfWork;

    public HomeController()
    {
      _unitOfWork = new UnitOfWork(ConnectionString);
    }

    public ActionResult Index()
    {
      ViewBag.User = _unitOfWork.Users.GetAll();
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