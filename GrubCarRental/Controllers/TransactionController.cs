using GrubCarRental.Data;
using GrubCarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrubCarRental.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TransactionController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<TransactionDetails> objTransactionList = (
                from t in _db.Transactions
                join r in _db.Renters on t.RenterId equals r.RenterId into table1
                from r in table1.DefaultIfEmpty()
                join c in _db.Cars on t.CarId equals c.CarId into table2
                from c in table2.DefaultIfEmpty()
                select new TransactionDetails
                {
                    TransactionId = t.TransactionID,
                    Name = r.FirstName + " " + r.LastName,
                    Brand = c.Brand,
                    Type = c.Type,
                    BorrowedDate = t.BorrowedDate,
                    ReturnDate = t.ReturnDate
                }
                );
            return View(objTransactionList);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Transaction obj)
        {
            if (ModelState.IsValid)
            {
                _db.Transactions.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Transaction added successfully!";
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
            var transactionFromDb = _db.Transactions.Find(id);
            if (transactionFromDb == null)
            {
                return NotFound();
            }
            return View(transactionFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Transaction obj)
        {
            if (ModelState.IsValid)
            {
                _db.Transactions.Update(obj);
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
            var transactionFromDb = _db.Transactions.Find(id);
            if (transactionFromDb == null)
            {
                return NotFound();
            }
            return View(transactionFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Transaction obj)
        {
            var transactionFromDb = _db.Transactions.Find(obj.TransactionID);
            if (transactionFromDb == null)
            {
                return NotFound();
            }
            _db.Transactions.Remove(transactionFromDb);
            _db.SaveChanges();
            TempData["success"] = "Deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
