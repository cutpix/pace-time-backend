using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using PaceTime.WebAPI.Data;
using PaceTime.WebAPI.Managers;
using System.Configuration;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using BooksAPI.Identity;
using PaceTime.WebAPI.Identity;
using Microsoft.AspNet.Identity;

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
            var audience = ConfigurationManager.AppSettings["audience"];
            var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["secret"]);

            app.CreatePerOwinContext(() => new FitnessContext());
            app.CreatePerOwinContext(() => new SecurityContext());
            app.CreatePerOwinContext(() => new SecurityUserManager());


            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ExternalBearer,
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { audience },
                IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                {
                    new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                }
            });

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                AuthenticationType = DefaultAuthenticationTypes.ExternalBearer,
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat(issuer, audience)
            });
        }
    }
}
