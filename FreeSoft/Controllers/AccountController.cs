using System.Linq;
using System.Web.Mvc;
using FreeSoft.Models;

namespace FreeSoft.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.UserAccounts.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.UserAccounts.Add(userAccount);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = userAccount.FirstName + " " + userAccount.LastName + " successfuly registered";
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount userAccount)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.UserAccounts.Single(u => u.Username == userAccount.Username && u.Password == userAccount.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoggetIn");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password is wrong.");
                }
            }
            return View();
        }

        public ActionResult LoggetIn()
        {
            if (Session["UserID"]!= null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            //return View();
        }
    }
}