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
        public bool isFahrenheit { get; set; } = false;

        public double CelsiusLow => Math.Round((Low - 32.0) * .5556);
        public double CelsiusHigh => Math.Round((High - 32.0) * .5556);

        private string GetFormattedFahrenheitLow()
        {
            return String.Format("{0}°F", Low);
        }
        private string GetFormattedFahrenheitHigh()
        {
            return String.Format("{0}°F", High);
        }
        private string GetFormattedCelsiusLow()
        {
            return String.Format("{0}°C", CelsiusLow);
        }
        private string GetFormattedCelsiusHigh()
        {
            return String.Format("{0}°C", CelsiusHigh);
        }

        public string GetPreferredLowTemp()
        {
            if (isFahrenheit)
            {
                return GetFormattedFahrenheitLow();
            }
            else
            {
                return GetFormattedCelsiusLow();
            }
        }
        public string GetPreferredHighTemp()
        {
            if (isFahrenheit)
            {
                return GetFormattedFahrenheitHigh();
            }
            else
            {
                return GetFormattedCelsiusHigh();
            }
        }

        //THis method removes all whitespace in the forecast so you are able to call the image name
        public string GetImgName()
        {
            char[] s = Forecast.ToCharArray();
            String withoutspaces = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                    withoutspaces += s[i];

            }
            return withoutspaces;

        }

        public string GetWeatherMessage()
        {
            Dictionary<string, string> forecastMessage = new Dictionary<string, string>()
            {
                {"rain","Pack rain gear and wear waterproof shoes!" },{"partly cloudy","Enjoy the shade!"},
                { "thunderstorms","Make sure to seek shelter and avoid hiking on exposed ridges!" },{"sun","Make sure to pack sunblock!"},
                { "snow","Watch out for Yetis! Oh and pack your snow shoes"}, {"sunny","Make sure to pack sunblock!"},{"cloudy","Enjoy the shade!"}
            };

            string result = forecastMessage[Forecast];
            return result;
        }
    }
}