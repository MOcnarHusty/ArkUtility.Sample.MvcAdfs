using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Provider;

namespace ArkUtility.Sample.MvcAdfs
{
    public static class AppOptions
    {
        private static string _appName { get; set; }

        public static string GetAppName()
        {
            return _appName;
        }

        public static void SetAppOptions()
        {
            //TODO: Ensure you update your application name in the web.config and then remove this todo note.
            _appName = ConfigurationManager.AppSettings["ApplicationName"] ?? "Application";
        }
    }
}