﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL.Interfaces
{
    public interface ISurveyDAL
    {
        List<FavoriteViewModel> GetSurveys();
        void SaveSurvey(Survey survey);
    }
}
