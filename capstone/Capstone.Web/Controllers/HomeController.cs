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
            List<Park> parks = _parkdal.GetAllParks();
            
            return View("Index", parks);
        }
        
        // GET: Home/Detail
        public ActionResult Detail(string parkCode,string scale)
        {
            if (scale == null)
            {
                scale = "true";
            }
            else
            {
                Session["temp"] = scale;
                Session["button"] = scale;
            }

         
            ParkDetailViewModel model = new ParkDetailViewModel();
            
                List<Weather> forecast = _weatherDAL.GetFiveDayForecast(parkCode);
                Park park = _parkdal.GetParkByCode(parkCode);
                
                model.PopulateParkProperties(park);
                model.PopulateForecast(forecast);
                model.IsFahrenheit = Convert.ToBoolean(Session["temp"]);
                    
                return View("Detail", model);  
        }
        
        // GET: Home/Survey
        public ActionResult Survey()
        {
            Survey survey = new Survey();
            PopulateParkMenu(_parkdal.GetParksForMenu(), survey);

            return View("Survey", survey);
        }

        // POST: Home/Survey
        [HttpPost]
        public ActionResult Survey(Survey survey)
        {
            ActionResult result;

            //Validate the model before proceeding
            if (!ModelState.IsValid)
            {
                PopulateParkMenu(_parkdal.GetParksForMenu(), survey);
                result = View("Survey", survey);
            }
            else
            {
                _surveyDal.SaveSurvey(survey);
                result = RedirectToAction("Favorites", survey);
            }
            return result;
        }
        
        // GET: Home/Favorites
        public ActionResult Favorites()
        {
            var model = _surveyDal.GetSurveys();
            return View("Favorites", model);
        }

        /// <summary>
        /// Method to add the parks to the menu used on Survey page, will scale to any number
        /// of parks from the DB
        /// </summary>
        /// <param name="list">an IList of menu items</param>
        /// <param name="survey">survey object</param>
        private void PopulateParkMenu(IList<SelectListItem> list, Survey survey)
        {
            survey.Parks.AddRange(list);
        }
    }
}