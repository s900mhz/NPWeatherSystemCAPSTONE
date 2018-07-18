using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.DAL.Interfaces;
using System.Data.SqlClient;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        string _connection = "";
        public SurveySqlDAL(string connection)
        {
            _connection = connection;
        }

        public List<Survey> GetSurveys()
        {
            List<Survey> parks = new List<Survey>();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                const string sqlParkCommand = "SELECT[surveyId], [parkCode], [emailAddress],[state],[activityLevel] FROM[NPGeek].[dbo].[survey_result]";
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

        public void SaveSurvey(Survey survey)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                const string sqlForumCommand = "INSERT INTO survey_result (parkCode,emailAddress,state,activityLevel) " +
                                               "VALUES (@parkCode,@emailAddress,@state,@activityLevel)";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@parkCode", post.Username);
                cmd.Parameters.AddWithValue("@emailAddress", post.Subject);
                cmd.Parameters.AddWithValue("@state", post.Message);
                cmd.Parameters.AddWithValue("@activityLevel", post.PostDate);
                cmd.CommandText = sqlForumCommand;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
        }
    }
}