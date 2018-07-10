using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BlackJack.DAL.Enteties;

namespace BlackJack.Controllers
{
  public class HomeController : Controller
  {
    private static readonly string _connectionString = "Default";
    private readonly UnitOfWork _unitOfWork;

    public HomeController()
    {
      _unitOfWork = new UnitOfWork(_connectionString);
    }

    public ActionResult Index()
    {
      ViewBag.User = _unitOfWork.Users.GetAll().ToList();

      return View();
    }

    [HttpGet]
    public ActionResult Hand(int id)
    {
      //var commentsOfMember = _unitOfWork.Users
      //  .Where(us => us.Id == id)
      //  .Select(us => us.Cards)
      //  .ToList();
      //ViewBag.UserId = id;
      ViewBag.Cards = _unitOfWork.Cards.GetAll();
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}