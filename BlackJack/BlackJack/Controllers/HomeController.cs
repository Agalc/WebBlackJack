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
      ViewBag.User = _unitOfWork.Users.GetAll();
      return View();
    }

    [HttpGet]
    public ActionResult Hand(int id)
    {
      ViewBag.UserId = id;
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