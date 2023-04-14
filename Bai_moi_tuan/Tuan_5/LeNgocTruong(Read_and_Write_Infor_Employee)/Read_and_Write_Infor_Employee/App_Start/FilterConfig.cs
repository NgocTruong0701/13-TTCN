using System.Web;
using System.Web.Mvc;

namespace Read_and_Write_Infor_Employee
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
