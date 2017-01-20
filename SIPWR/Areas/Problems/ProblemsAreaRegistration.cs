using System.Web.Mvc;

namespace SIPWR.Areas.Problems
{
    public class ProblemsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Problems";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Problems_default",
                "Problems/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}