using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using PaceTime.WebAPI.Data;
using PaceTime.WebAPI.Managers;
using System.Configuration;
using Microsoft.Owin.Security.DataHandler.Encoder;

[assembly: OwinStartup(typeof(PaceTime.WebAPI.Startup))]

namespace PaceTime.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var issuer = ConfigurationManager.AppSettings["issuer"];
            var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["secret"]);

            app.CreatePerOwinContext(() => new BooksContext());
            app.CreatePerOwinContext(() => new BookUserManager());
        }
    }
}
