using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
	    public int FiveDayForecastValue { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
        public string Forecast { get; set; }

        public double CelsiusLow => Math.Round((Low - 32.0) * .5556);
        public double CelsiusHigh => Math.Round((High - 32.0) * .5556);

        public string GetFormattedFahrenheitLow()
        {
            return String.Format("{0}°F", Low);
        }
        public string GetFormattedFahrenheitHigh()
        {
            return String.Format("{0}°F", High);
        }
        public string GetFormattedCelsiusLow()
        {
            return String.Format("{0}°C", CelsiusLow);
        }
        public string GetFormattedCelsiusHigh()
        {
            return String.Format("{0}°C", CelsiusHigh);
        }
    }
}