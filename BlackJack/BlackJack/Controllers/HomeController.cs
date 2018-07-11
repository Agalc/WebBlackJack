using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BlackJack.DAL.Enteties;
using BlackJack.DAL.Interfaces;

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
      ViewBag.Cards = _unitOfWork.Cards.GetAll();
      return View();
    }
  }
}