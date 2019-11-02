using System.Web.Mvc;

namespace Market.Areas.MarketAdmin
{
    public class MarketAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MarketAdmin";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MarketAdmin_default",
                "MarketAdmin/{controller}/{action}/{id}",
                new { controller="home" ,action = "Index", id = UrlParameter.Optional },
                new string[] { "Market.Areas.MarketAdmin.Controllers"}
            );
        }
    }
}