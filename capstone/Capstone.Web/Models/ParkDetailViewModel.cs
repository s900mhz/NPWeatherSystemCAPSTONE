using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkDetailViewModel
    {
        #region Properties
        //park detail properties
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public double MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public int EntryFee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }
        public bool IsFahrenheit { get; set; } = true;
        public List<Weather> Forecast { get; set; }
        //from weather model properties, as reference:
        //public int FiveDayForecastValue { get; set; }
        //public int Low { get; set; }
        //public int High { get; set; }
        //public string Forecast { get; set; }
        #endregion
            
        #region Methods
        /// <summary>
        /// Populates park object properties for detail view page
        /// </summary>
        /// <param name="park">park object</param>
        public void PopulateParkProperties(Park park)
        {
            ParkCode = park.ParkCode;
            ParkName = park.ParkName;
            State = park.State;
            Acreage = park.Acreage;
            ElevationInFeet = park.ElevationInFeet;
            MilesOfTrail = park.MilesOfTrail;
            NumberOfCampsites = park.NumberOfCampsites;
            Climate = park.Climate;
            YearFounded = park.YearFounded;
            AnnualVisitorCount = park.AnnualVisitorCount;
            InspirationalQuote = park.InspirationalQuote;
            InspirationalQuoteSource = park.InspirationalQuoteSource;
            ParkDescription = park.ParkDescription;
            EntryFee = park.EntryFee;
            NumberOfAnimalSpecies = park.NumberOfAnimalSpecies;
        }

        /// <summary>
        /// Populates a list of weather objects for the 5-day forecast
        /// </summary>
        /// <param name="forecast">a list of weather objects</param>
        public void PopulateForecast(List<Weather> forecast)
        {
            Forecast = forecast;
        }

        /// <summary>
        /// This method takes the bool from the checkbox in the view, feeds it in and then switches all the temp types in the forecast
        /// </summary>
        public void ToggleTempType()
        {
            if (IsFahrenheit)
            {
                foreach (var weather in Forecast)
                {
                    weather.isFahrenheit = true;
                }
            }
            else
            {
                foreach (var weather in Forecast)
                {
                    weather.isFahrenheit = false;
                }
            }
        }
        #endregion
    }
}