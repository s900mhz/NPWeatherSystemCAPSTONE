using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.DAL.Interfaces;
using System.Data.SqlClient;
using Capstone.Web.Models;
using System.Web.Mvc;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        #region Member Variables
        string _connection = "";
        #endregion

        #region Methods
        /// <summary>
        /// constructor
        /// </summary>
        public ParkSqlDAL(string connection)
        {
            _connection = connection;
        }
        
        /// <summary>
        /// Get all the park details from DB
        /// </summary>
        /// <returns>a List of Park objects</returns>
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
                    park.Climate = Convert.ToString(reader["climate"]);
                    park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                    park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                    park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                    park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                    park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                    park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                    park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

                    parks.Add(park);
                }
            }
            return parks;
        }

        /// <summary>
        /// gets the Park details from a specific parkCode
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns>a populated Park Object</returns>
        public Park GetParkByCode(string parkCode)
        {
           Park park = new Park();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                const string sqlParkCommand = "SELECT [parkCode] ,[parkName],[state],[acreage],[elevationInFeet],[milesOfTrail],[numberOfCampsites],[climate],[yearFounded],[annualVisitorCount],[inspirationalQuote],[inspirationalQuoteSource],[parkDescription],[entryFee],[numberOfAnimalSpecies] FROM [NPGeek].[dbo].[park] WHERE parkCode = @parkcode";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sqlParkCommand;
                cmd.Parameters.AddWithValue("@parkcode", parkCode);
                cmd.Connection = connection;

                //Pull data off the table
                SqlDataReader reader = cmd.ExecuteReader();

                //Looping through the table and populating the list with all the rows
                while (reader.Read())
                {

                    park.ParkCode = Convert.ToString(reader["parkCode"]);
                    park.ParkName = Convert.ToString(reader["parkName"]);
                    park.State = Convert.ToString(reader["state"]);
                    park.Acreage = Convert.ToInt32(reader["acreage"]);
                    park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                    park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                    park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                    park.Climate = Convert.ToString(reader["climate"]);
                    park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                    park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                    park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                    park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                    park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                    park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                    park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]); 
                }
            }
            return park;
        }

        /// <summary>
        /// gets the list of Parks and codes from the DB to
        /// populate the drop down. Scales to any number of parks added later
        /// </summary>
        /// <returns>an IList in SelectListItem format for a menu</returns>
        public IList<SelectListItem> GetParksForMenu()
        {
            List<SelectListItem> parks = new List<SelectListItem>();
            
            string sqlquery = "Select [parkCode],[parkName] FROM [NPGeek].[dbo].[park]";
            
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlquery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SelectListItem selectListItem = new SelectListItem();
                        selectListItem.Text = Convert.ToString(reader["parkName"]);
                        selectListItem.Value = Convert.ToString(reader["parkCode"]);
                        parks.Add(selectListItem);
                    }
                }
                catch (Exception ex)
                {
                    // Handle the error
                }
                return parks;
            }
        }
        #endregion
    }
}