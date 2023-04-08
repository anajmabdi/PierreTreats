using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectName.Controllers
{
  public class ClassNamesController : Controller
  {
    private readonly ProjectNameContext _db;

    public ClassNamesController(ProjectNameContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {

    }
  }
}