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
            List<Survey> surveys = new List<Survey>();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                const string sqlParkCommand = "SELECT[surveyId], [parkCode], [emailAddress],[state],[activityLevel] FROM[NPGeek].[dbo].[survey_result]";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sqlParkCommand;
                cmd.Connection = connection;

                //Pull data off the table
                SqlDataReader reader = cmd.ExecuteReader();

                
                while (reader.Read())
                {
                    Survey survey= new Survey();

                    survey.SurveyId = Convert.ToInt32(reader["surveyId"]);
                    survey.UserParkChoice = Convert.ToString(reader["parkCode"]);
                    survey.EmailAddress = Convert.ToString(reader["emailAddress"]);
                    survey.UserStateChoice = Convert.ToString(reader["state"]);
                    survey.UserActivityChoice= Convert.ToString(reader["activityLevel"]);
                    
                    surveys.Add(survey);
                }
            }
            return surveys;
        }

        public void SaveSurvey(Survey survey)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                const string sqlForumCommand = "INSERT INTO survey_result (parkCode,emailAddress,state,activityLevel) VALUES (@parkCode,@emailAddress,@state,@activityLevel)";
                
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@parkCode", survey.UserParkChoice);
                cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                cmd.Parameters.AddWithValue("@state", survey.UserStateChoice);
                cmd.Parameters.AddWithValue("@activityLevel", survey.UserActivityChoice);
                cmd.CommandText = sqlForumCommand;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
        }
    }
}