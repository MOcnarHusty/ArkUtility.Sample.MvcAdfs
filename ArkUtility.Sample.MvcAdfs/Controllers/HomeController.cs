using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;

namespace ArkUtility.Sample.MvcAdfs.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyClaims()
        {
            var claimsIdentity = System.Threading.Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            ViewBag.ClaimsIdentity = claimsIdentity;
            ViewBag.DisplayName = claimsIdentity?.Claims?.First(x => x.Type == ClaimTypes.GivenName).Value;
            return View();
        }

        public ActionResult Logon(string returnUrl)
        {
            return Redirect(returnUrl ?? Url.Action("Index","Home"));
        }
        public ActionResult LogOff()
        {
            if (User.Identity.IsAuthenticated)
            {
                var owinContext = Request.GetOwinContext();
                var authProps = new AuthenticationProperties();
                authProps.RedirectUri = new Uri(HttpContext.Request.Url,
                    new UrlHelper(ControllerContext.RequestContext).Action("PostLogOff")).AbsoluteUri;
                owinContext.Authentication.SignOut(authProps);
                return null;
            }
            else
            {
                throw new InvalidOperationException("User is not authenticated");
            }
        }
        [AllowAnonymous]
        public ActionResult PostLogOff()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}