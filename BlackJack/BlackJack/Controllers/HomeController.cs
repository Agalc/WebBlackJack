using System.Web.Mvc;
using BlackJack.DAL;
using BlackJack.DAL.Enteties;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Repositories;

namespace BlackJack.Controllers
{
  public class HomeController : Controller
  {
    private static BjContext _context = new BjContext("Default");
    private IRepository<User> _userDatabase = new UserRepository(_context);

    public ActionResult Index()
    {
      ViewBag.User = _userDatabase.GetAll();
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