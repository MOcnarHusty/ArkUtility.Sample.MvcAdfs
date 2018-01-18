using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.WsFederation;
using Owin;

[assembly: OwinStartup(typeof(ArkUtility.Sample.MvcAdfs.Startup))]

namespace ArkUtility.Sample.MvcAdfs
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //Cookie Auth
            var cookieOptions =
                new CookieAuthenticationOptions {AuthenticationType = CookieAuthenticationDefaults.AuthenticationType};
            app.UseCookieAuthentication(cookieOptions);

            //TODO: Ensure you update your application settings for your ADFS Config and then remove this todo note.
            //TODO: Remember you will need the ADFS admin to configure a relying partner and rules for your application and then remove this todo note.
            //WS Fed Auth (Uses cookies to store info)
            var wsFedOptions = new WsFederationAuthenticationOptions
            {
                MetadataAddress = ConfigurationManager.AppSettings["ida:ADFSMetadata"],//"https://youradfsserver.address.com/FederationMetadata/2007-06/FederationMetadata.xml",
                Wtrealm = ConfigurationManager.AppSettings["ida:Wtrealm"],//Example: https://yourwebsite/Account/LoginCallbackAdfs,
                Wreply = ConfigurationManager.AppSettings["ida:Wreply"],//Example: https://yourwebsite/Account/LoginCallbackAdfs || ""
            };
            app.UseWsFederationAuthentication(wsFedOptions);
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
        }
    }
}
