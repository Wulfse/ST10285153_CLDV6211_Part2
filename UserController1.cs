using Microsoft.AspNetCore.Mvc;
using CLDVPart1.Models;
namespace CLDVPart1.Controllers
{
    public class UserController1 : Controller
    {
        public User usrtbl = new User();

        [HttpPost]
        public ActionResult SignUp(User Users)
        {
            var result = usrtbl.insert_User(Users);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userID");
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult SignUp()
        {
            return View(usrtbl);
        }
        public ActionResult Login()
        {
            return View(usrtbl);
        }
    }
}

