using Microsoft.AspNetCore.Mvc;
using PierreTreats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierreTreats.Controllers
{
    public class TreatsController : Controller
    {
        private readonly PierreTreatsContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TreatsController(UserManager<ApplicationUser> userManager, PierreTreatsContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
            List<Treat> userTreats = _db.Treats
                                    .Where(entry => entry.User.Id == currentUser.Id)
                                    .ToList();
            return View(userTreats);
        }


        [Authorize]
        public ActionResult Details(int id)
        {
            Treat thisTreat = _db.Treats
                .Include(treat => treat.JoinEntities)
                .ThenInclude(join => join.Flavor)
                .FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Treat treat)
        {
            if (!ModelState.IsValid)
            {
                return View(treat);
            }
            else
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
                treat.User = currentUser;
                _db.Treats.Add(treat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult AddFlavor(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Description");
            return View(thisTreat);
        }

        [HttpPost]
        public ActionResult AddFlavor(Treat treat, int flavorId)
        {
#nullable enable
            TreatFlavor? joinEntity = _db.TreatFlavors.FirstOrDefault(join => (join.FlavorId == flavorId && join.TreatId == treat.TreatId));
#nullable disable
            if (joinEntity == null && flavorId != 0)
            {
                _db.TreatFlavors.Add(new TreatFlavor() { TreatId = treat.TreatId, FlavorId = flavorId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = treat.TreatId });
        }

        public ActionResult Edit(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            _db.Treats.Update(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(tags => tags.TreatId == id);
            _db.Treats.Remove(thisTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteJoin(int joinId)
        {
            TreatFlavor joinEntry = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
            _db.TreatFlavors.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}