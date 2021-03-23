using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Icarus.Controllers
{
    public class NavBarController : Controller
    {
        // GET: NavBar
        public ActionResult Index()
        {
            return View("NavBar");
        }
    }
}