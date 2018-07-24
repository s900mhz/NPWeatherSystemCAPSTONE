using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Weather
    {
        #region Constants
        public const string HeatWarning = "Bring an extra gallon of water!";
        public const string TempSwing = "Be sure to wear breathable layers!";
        public const string FreezeWarning = "Be aware of frigid temperatures and pack accordingly!";
        #endregion

        #region Properties
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
        public string Forecast { get; set; }
        public bool isFahrenheit { get; set; } = false;

        public double CelsiusLow => Math.Round((Low - 32.0) * .5556);
        public double CelsiusHigh => Math.Round((High - 32.0) * .5556);
        #endregion

        #region Methods
        /// <summary>
        /// Method for returning low farenheit temp
        /// </summary>
        /// <returns></returns>
        private string GetFormattedFahrenheitLow()
        {
            return String.Format("{0}°F", Low);
        }

        /// <summary>
        /// method for return high farenheit temp
        /// </summary>
        /// <returns></returns>
        private string GetFormattedFahrenheitHigh()
        {
            return String.Format("{0}°F", High);
        }

        /// <summary>
        /// method for return low celsius temp
        /// </summary>
        /// <returns></returns>
        private string GetFormattedCelsiusLow()
        {
            return String.Format("{0}°C", CelsiusLow);
        }

        /// <summary>
        /// method for returning high celsius temp
        /// </summary>
        /// <returns></returns>
        private string GetFormattedCelsiusHigh()
        {
            return String.Format("{0}°C", CelsiusHigh);
        }

        /// <summary>
        /// method to return preferred low temp from C/F toggle by user
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// method to return preferred high temp from C/F toggle by user
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// THis method removes all whitespace in the forecast so you are able to call the image name
        /// </summary>
        /// <returns>name as string without spaces</returns>
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

        /// <summary>
        /// Method to return the message as a string, from the dictionary
        /// </summary>
        /// <returns>string message corresponding to a string key of the forecast type</returns>
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

        /// <summary>
        /// Method to return unique weather notifications based on specific conditions
        /// </summary>
        /// <param name="lowTemp">low temp in F</param>
        /// <param name="highTemp">high temp in F</param>
        /// <returns>a HashSet of unique message(s) to be utilized if condition(s) are met below </returns>
        public HashSet<string> GetUniqueTempNotification()
        {
            var temperatureNotification = new HashSet<string>();
            double lowTemp = Low;
            double highTemp = High;
            if (highTemp > 75 || lowTemp > 75)
            {
                temperatureNotification.Add(HeatWarning);
            }
            if (highTemp - lowTemp > 20)
            {
                temperatureNotification.Add(TempSwing);
            }
            if (lowTemp < 20 || highTemp < 20)
            {
                temperatureNotification.Add(FreezeWarning);
            }
            return temperatureNotification;
        }
        #endregion
    }
}