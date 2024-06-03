using Microsoft.Data.SqlClient;
using CLDVPart1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;


namespace CLDVPart1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Retrieve all products from the database
            List<Product> products = Product.get_Products();

            // Pass products and userID to the view
            int? userID = HttpContext.Session.GetInt32("userID");
            ViewData["UserID"] = userID;

            return View(products);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult MyWork()
        {
            var products = _context.Products.ToList(); // Fetch products from the database
            return View(products);
        }

        public ActionResult Transactions()
        {
            
            return View();
        }

        public ActionResult AddProducts()
        {
            return View();
        }
    

    [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult PlaceOrder(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
                return RedirectToAction("MyWork");
            }
            return View(transaction);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
