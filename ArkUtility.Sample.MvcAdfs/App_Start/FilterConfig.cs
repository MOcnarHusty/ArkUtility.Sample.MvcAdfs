using System.Web;
using System.Web.Mvc;

namespace ArkUtility.Sample.MvcAdfs
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
