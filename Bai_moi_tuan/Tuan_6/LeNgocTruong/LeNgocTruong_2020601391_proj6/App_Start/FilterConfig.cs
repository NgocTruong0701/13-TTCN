using System.Web;
using System.Web.Mvc;

namespace LeNgocTruong_2020601391_proj6
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
