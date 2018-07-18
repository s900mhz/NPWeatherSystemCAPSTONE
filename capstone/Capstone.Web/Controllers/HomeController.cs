using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IWeatherDAL _weatherDAL;
        private ISurveyDAL _surveyDal;
        private IParkDAL _parkdal;
        public HomeController(IParkDAL parkDAL, ISurveyDAL surveyDAL, IWeatherDAL weatherDAL)
        {
            _parkdal = parkDAL;
            _surveyDal = surveyDAL;
            _weatherDAL = weatherDAL;
        }

        // GET: /
        // GET: Home/
        // GET: Home/Index
        public ActionResult Index()
        {  
            return View("Index");
        }


        // GET: Home/Detail
        public ActionResult Detail()
        {
            return View("Detail");
        }


        // GET: Home/Survey
        public ActionResult Survey()
        {
            return View("Survey");
        }

        // POST: Home/Survey
        [HttpPost]
        public ActionResult Survey(Survey survey)
        {


            return RedirectToAction("Favorites");
        }


        // GET: Home/Favorites
        public ActionResult Favorites()
        {
            return View("Favorites");
        }
    }
}