using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using PaceTime.WebAPI.Data;
using PaceTime.WebAPI.Managers;

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
            app.CreatePerOwinContext(() => new BooksContext());
            app.CreatePerOwinContext(() => new BookUserManager());
        }
    }
}
