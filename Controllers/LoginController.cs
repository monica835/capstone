using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Icarus.Models;

namespace Icarus.Controllers
{
    public class LoginController : Controller
    {
        private ICARUSDBEntities db = new ICARUSDBEntities();

        [Route("/login")]
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [Route("/Login")]
        public ActionResult Login()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Login(tblStaff user)
        {
            var checkLogin = db.tblStaffs.Where(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["IDStaff"] = user.IDStaff.ToString();
                Session["Username"] = user.Username.ToString();
                return RedirectToAction("Index", "Resident");
            }
            else {
                ViewBag.Notification = "Username or Password doesn't match!";
            }
            return View();
        }
    }
}