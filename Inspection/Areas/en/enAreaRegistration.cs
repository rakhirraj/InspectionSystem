using System.Web.Mvc;

namespace Inspection.Areas.en
{
    public class enAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "en";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "en_home",
                "en/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Inspection.Areas.en.Controllers" }
            );

            context.MapRoute(
               "en_default",
               "",
               new { controller = "Account", action = "login", id = UrlParameter.Optional },
               new[] { "Inspection.Areas.en.Controllers" }
           );
        }
    }
}