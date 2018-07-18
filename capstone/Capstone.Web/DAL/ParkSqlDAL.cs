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

                    forumPost.Id = Convert.ToInt32(reader["id"]);
                    forumPost.Username = Convert.ToString(reader["username"]);
                    forumPost.Subject = Convert.ToString(reader["subject"]);
                    forumPost.Message = Convert.ToString(reader["message"]);
                    forumPost.PostDate = Convert.ToDateTime(reader["post_date"]);



                    parks.Add(park);
                }
            }

            return parks;
        }
    }
}