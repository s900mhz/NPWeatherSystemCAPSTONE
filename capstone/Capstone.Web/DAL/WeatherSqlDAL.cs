using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAL : IWeatherDAL
    {
        string _connection = "";
        public WeatherSqlDAL(string connection)
        {
            _connection = connection;
        }

        public List<Weather> GetFiveDayForecast(Park park)
        {
            List<Weather> forecast = new List<Weather>();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                const string sqlForumCommand = "SELECT [parkCode],[fiveDayForecastValue],[low],[high],[forecast] FROM [NPGeek].[dbo].[weather] WHERE parkCode = @parkCode";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@parkCode", park.ParkCode);
                cmd.CommandText = sqlForumCommand;
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();

                //Looping through the table and populating the list with all the rows
                while (reader.Read())
                {
                    Weather weather = new Weather();

                    weather.ParkCode = Convert.ToString(reader["parkCode"]);
                    weather.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                    weather.Low = Convert.ToInt32(reader["low"]);
                    weather.High = Convert.ToInt32(reader["high"]);
                    weather.Forecast = Convert.ToString(reader["forecast"]);


                    forecast.Add(weather);
                }
            }
            return forecast;
        }
    }
}