﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.DAL.Interfaces
{
    public interface IWeatherDAL
    {
        List<Weather> GetFiveDayForecast(string parkCode);
    }
}