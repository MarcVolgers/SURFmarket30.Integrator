using System.Web;
using System.Web.Mvc;

namespace SURF.SurfMarket30.Integrator
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
