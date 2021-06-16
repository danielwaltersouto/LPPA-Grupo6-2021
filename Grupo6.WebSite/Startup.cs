﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;

namespace Grupo6.WebSite
{
    public class Startup
    {
        public void Configuracion(IAppBuilder app)
        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            { AuthenticationType = "ApplicationCookie",
             LoginPath = new PathString ("/Auth/LogIn")});
        }

    }
}