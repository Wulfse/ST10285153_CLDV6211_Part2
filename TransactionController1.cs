using Microsoft.AspNetCore.Mvc;
using CLDVPart1.Models;
using Microsoft.AspNetCore.Http;

namespace CLDVPart1.Controllers
{
    public class TransactionController1 : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionController1(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Transactions()
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            if (userID == null)
            {
                TempData["AlertMessage"] = "Please Login to view transactions";
                return RedirectToAction("Login", "User");
            }

            var transactions = Transaction.GetTransactions(userID.Value, _context);
            return View(transactions);
        }

        [HttpPost]
        public IActionResult AddTransaction(int productID, int quantity)
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            if (userID == null)
            {
                TempData["AlertMessage"] = "Please Login to purchase a product";
                return RedirectToAction("Login", "User");
            }

            var transaction = new Transaction
            {
                UserID = userID.Value,
                ProductID = productID,
                Quantity = quantity,
                TransactionDate = DateTime.Now
            };

            Transaction.PlaceOrder(transaction, _context);

            return RedirectToAction("MyWork", "Product");
        }
    }
}