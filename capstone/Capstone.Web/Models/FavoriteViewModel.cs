using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class FavoriteViewModel
    {
        #region Properties
        public int SurveyId { get; set; }
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public int NumOfSurveys { get; set; }
        #endregion
    }
}