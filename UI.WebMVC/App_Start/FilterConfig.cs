using System.Web;
using System.Web.Mvc;
using UI.WebMVC.Filters;

namespace UI.WebMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new VerificaSession());
        }
    }
}
