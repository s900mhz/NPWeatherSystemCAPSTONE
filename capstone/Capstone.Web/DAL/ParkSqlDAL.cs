using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.DAL.Interfaces;
using System.Data.SqlClient;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        string _connection = "";
        public ParkSqlDAL(string connection)
        {
            _connection = connection;
        }

        public List<Park> GetAllParks()
        {
            List<Park> parks = new List<Park>();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                const string sqlParkCommand = "SELECT [parkCode] ,[parkName],[state],[acreage],[elevationInFeet],[milesOfTrail],[numberOfCampsites],[climate],[yearFounded],[annualVisitorCount],[inspirationalQuote],[inspirationalQuoteSource],[parkDescription],[entryFee],[numberOfAnimalSpecies] FROM [NPGeek].[dbo].[park]";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sqlParkCommand;
                cmd.Connection = connection;

                //Pull data off the table
                SqlDataReader reader = cmd.ExecuteReader();

                //Looping through the table and populating the list with all the rows
                while (reader.Read())
                {
                    Park park = new Park();

                    park.ParkCode = Convert.ToString(reader["parkCode"]);
                    park.ParkName = Convert.ToString(reader["parkName"]);
                    park.State = Convert.ToString(reader["state"]);
                    park.Acreage = Convert.ToInt32(reader["acreage"]);
                    park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                    park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                    park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                    park.ElevationInFeet = Convert.ToInt32(reader["climate"]);
                    park.ElevationInFeet = Convert.ToInt32(reader["yearFounded"]);
                    park.ElevationInFeet = Convert.ToInt32(reader["annualVisitorCount"]);
                    park.ElevationInFeet = Convert.ToInt32(reader["inspirationalQuote"]);
                    park.ElevationInFeet = Convert.ToInt32(reader["inspirationalQuoteSource"]);
                    park.ElevationInFeet = Convert.ToInt32(reader["parkDescription"]);
                    park.ElevationInFeet = Convert.ToInt32(reader["entryFee"]);
                    park.ElevationInFeet = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

                    parks.Add(park);
                }
            }
            return parks;
        }
    }
}