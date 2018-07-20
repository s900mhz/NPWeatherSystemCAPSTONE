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
        #region Member Variables
        string _connection = "";
        #endregion

        #region Methods
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="connection">connection string</param>
        public SurveySqlDAL(string connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Gets all survey data from DB
        /// </summary>
        /// <returns>a List of Survey objects</returns>
        public List<FavoriteViewModel> GetSurveys()
        {
            List<FavoriteViewModel> result = new List<FavoriteViewModel>();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                const string sqlParkCommand = "select COUNT(survey_result.parkCode) as parkCount, park.parkCode, Park.parkName, Park.parkDescription " +
                    "from survey_result JOIN park on park.parkCode = survey_result.parkCode " +
                    "group by Park.parkDescription, park.parkName, park.parkCode " +
                    "order by COUNT(survey_result.parkCode) desc;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sqlParkCommand;
                cmd.Connection = connection;

                //Pull data off the table
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    var favorites= new FavoriteViewModel();
                    
                    favorites.ParkCode = Convert.ToString(reader["parkCode"]);
                    favorites.ParkName = Convert.ToString(reader["parkName"]);
                    favorites.NumOfSurveys= Convert.ToInt32(reader["parkCount"]);

                    result.Add(favorites);
                }
            }
            return result;
        }

        /// <summary>
        /// Saves a survey from the user in a survey object and 
        /// Inserts in the survey DB
        /// </summary>
        /// <param name="survey">takes a Survey object parameter</param>
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
        #endregion
    }
}