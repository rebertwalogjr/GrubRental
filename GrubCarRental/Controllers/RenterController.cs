using GrubCarRental.Data;
using GrubCarRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrubCarRental.Controllers
{
    public class RenterController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RenterController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Renter> objRenterList = _db.Renters;
            return View(objRenterList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Renter obj)
        {
            if (ModelState.IsValid)
            {
                _db.Renters.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "New Renter was added successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var renterFromDb = _db.Renters.Find(id);
            if (renterFromDb == null)
            {
                return NotFound();
            }
            return View(renterFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Renter obj)
        {
            if (ModelState.IsValid)
            {
                _db.Renters.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var renterFromDb = _db.Renters.Find(id);
            if (renterFromDb == null)
            {
                return NotFound();
            }
            return View(renterFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Renter obj)
        {
            var renterFromDb = _db.Renters.Find(obj.RenterId);
            if (renterFromDb == null)
            {
                return NotFound();
            }
            _db.Renters.Remove(renterFromDb);
            _db.SaveChanges();
            TempData["success"] = "Deleted successfully!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Search(string str)
        {
            var renters = from r in _db.Renters select r;
            if (!String.IsNullOrEmpty(str))
            {
                renters = renters.Where(s => s.FirstName!.Contains(str));
            }
            return View(await renters.ToListAsync());
        }
    }
}
