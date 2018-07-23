using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkDetailViewModel
    {
        #region Properties
        private bool _isFahrenheit;

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
        public bool IsFahrenheit
        {
            get
            {
               return _isFahrenheit;
            }
            set
            {
                _isFahrenheit = value;
                ToggleTempType();
            }
        }
        #endregion


        //weather properties to display
        //public int FiveDayForecastValue { get; set; }
        //public int Low { get; set; }
        //public int High { get; set; }
        //public string Forecast { get; set; }

        public List<Weather> Forecast { get; set; }

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
        public void PopulateForecast(List<Weather> forecast)
        {
            Forecast = forecast;
        }

        //This method takes the bool from the checkbox in the view, feeds it in and then switches all the temp types in the forecast
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
        
    }
}