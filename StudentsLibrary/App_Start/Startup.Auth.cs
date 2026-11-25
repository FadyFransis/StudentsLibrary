using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.IdentityModel.Logging;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Net.Http;

namespace StudentsLibrary
{
    public partial class Startup
    {

        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string aadInstance = EnsureTrailingSlash(ConfigurationManager.AppSettings["ida:AADInstance"]);
        private static string tenantId = ConfigurationManager.AppSettings["ida:TenantId"];
        private static string postLogoutRedirectUri = ConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];
        string authority = aadInstance + tenantId + "/v2.0";

        public void ConfigureAuth(IAppBuilder app)
        {
            IdentityModelEventSource.ShowPII = true;

            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            // DEV ONLY: Entra bypass, active only while <add key="DevAuth" value="true"/> is in Web.config (localhost only)
            if (string.Equals(ConfigurationManager.AppSettings["DevAuth"], "true", StringComparison.OrdinalIgnoreCase))
            {
                app.Use(async (ctx, next) =>
                {
                    if (ctx.Request.Uri.IsLoopback)
                    {
                        var email = ConfigurationManager.AppSettings["DevAuthEmail"] ?? "dev.student@local.test";
                        var id = new ClaimsIdentity("DevAuth", ClaimTypes.Name, ClaimTypes.Role);
                        id.AddClaim(new Claim(ClaimTypes.Name, email));
                        id.AddClaim(new Claim("preferred_username", email));
                        id.AddClaim(new Claim("name", ConfigurationManager.AppSettings["DevAuthName"] ?? "Dev Student"));
                        id.AddClaim(new Claim("groups", ConfigurationManager.AppSettings["DevAuthGroup"] ?? "Students"));
                        ctx.Request.User = new ClaimsPrincipal(id);
                    }
                    await next();
                });
                app.UseStageMarker(PipelineStage.Authenticate);
                return;
            }

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = clientId,
                    Authority = authority,
                    PostLogoutRedirectUri = postLogoutRedirectUri,

                    Notifications = new OpenIdConnectAuthenticationNotifications()
                    {
                        AuthenticationFailed = (context) =>
                        {
                            return System.Threading.Tasks.Task.FromResult(0);
                        },

                        SecurityTokenValidated = (context) =>
                        {
                            string name = context.AuthenticationTicket.Identity.FindFirst("preferred_username").Value;
                            context.AuthenticationTicket.Identity.AddClaim(new Claim(ClaimTypes.Name, name, string.Empty));
                            return System.Threading.Tasks.Task.FromResult(0);
                        }
                    }
                });

            // This makes any middleware defined above this line run before the Authorization rule is applied in web.config
            app.UseStageMarker(PipelineStage.Authenticate);

        }

        private static string EnsureTrailingSlash(string value)
        {
            if (value == null)
            {
                value = string.Empty;
            }

            if (!value.EndsWith("/", StringComparison.Ordinal))
            {
                return value + "/";
            }

            return value;
        }
    }
}