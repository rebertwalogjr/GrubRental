using GrubCarRental.Data;
using GrubCarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrubCarRental.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CarController(ApplicationDbContext db)
        {
            _db = db;   
        }

        public IActionResult Index()
        {
            IEnumerable<Car> objCarList = _db.Cars;
            return View(objCarList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car obj)
        {
            if (ModelState.IsValid)
            {
                _db.Cars.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "New car was added successfully!";
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
            var carFromDb = _db.Cars.Find(id);
            if(carFromDb == null)
            {
                return NotFound();
            }
            return View(carFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Car obj)
        {
            if (ModelState.IsValid)
            {
                _db.Cars.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var carFromDb = _db.Cars.Find(id);
            if (carFromDb == null)
            {
                return NotFound();
            }
            return View(carFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Car obj)
        {
            var carFromDb = _db.Cars.Find(obj.CarId);
            if (carFromDb == null)
            {
                return NotFound();
            }
            _db.Cars.Remove(carFromDb);
            _db.SaveChanges();
            TempData["success"] = "Deleted successfully!";
            return RedirectToAction("Index");
        }

    }
}
