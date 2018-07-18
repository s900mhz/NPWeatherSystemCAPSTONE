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
        public List<Weather> GetFiveDayForecast(Park park)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                const string sqlForumCommand = "Insert into forum_post (username, subject, message, post_date)" +
                                              " Values (@username, @subject, @message, @post_date);";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@username", post.Username);
                cmd.Parameters.AddWithValue("@subject", post.Subject);
                cmd.Parameters.AddWithValue("@message", post.Message);
                cmd.Parameters.AddWithValue("@post_date", post.PostDate);
                cmd.CommandText = sqlForumCommand;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
        }
    }
}