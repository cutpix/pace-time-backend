using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

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
        }
    }
}
