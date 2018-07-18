using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }

        // this needs to either pull in the list for drop down
        // or can be hard-coded in with SelectListItem??
        [Required(ErrorMessage = "Park Code is required")]
        [DataType(DataType.Text)]
        public string ParkCode { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "State is required")]
        [DataType(DataType.Text)]
        public string State { get; set; }

        [Required(ErrorMessage = "Activity is required")]
        [DataType(DataType.Text)]
        public string ActivityLevel { get; set; }
    }
}