﻿using Capstone.Web.DAL;
using Capstone.Web.DAL.Interfaces;
using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Capstone.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            string connectionString = ConfigurationManager.ConnectionStrings["NPGeek"].ConnectionString;
            kernel.Bind<IParkDAL>().To<ParkSqlDAL>().WithConstructorArgument("connection", connectionString);
            kernel.Bind<ISurveyDAL>().To<SurveySqlDAL>().WithConstructorArgument("connection", connectionString);
            kernel.Bind<IWeatherDAL>().To<WeatherSqlDAL>().WithConstructorArgument("connection", connectionString);

            return kernel;
        }
    }
}
