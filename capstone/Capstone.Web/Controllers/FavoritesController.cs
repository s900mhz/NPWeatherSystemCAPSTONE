using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class FavoritesController : Controller
    {
        // GET: Favorites
        public ActionResult Index()
        {
            return View();
        }
    }
}