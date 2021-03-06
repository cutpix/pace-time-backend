﻿using PaceTime.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace PaceTime.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(FilterConfig.Configure);

            Database.SetInitializer<SecurityContext>(new SecurityInitializer());
            Database.SetInitializer<FitnessContext>(new FitnessInitializer());
        }
    }
}
