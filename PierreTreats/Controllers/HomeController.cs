using Microsoft.AspNetCore.Mvc;
using PierreTreats.Models;
using System.Collections.Generic;
using System.Linq;

namespace PierreTreats.Controllers
{
  public class HomeController : Controller
  {
    private readonly PierreTreatsContext _db;

    public HomeController(PierreTreatsContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {        
      Treat[] treats = _db.Treats.ToArray();
      Flavor[] flavors = _db.Flavors.ToArray();
      Dictionary<string, object[]> model = new Dictionary<string, object[]>();
      model.Add("treats", treats);
      model.Add("flavors", flavors);
      return View(model);
    }

    public ActionResult About()
    {
      return View();
    }
  }
}
