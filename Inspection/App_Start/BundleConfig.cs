using System.Web;
using System.Web.Optimization;

namespace Inspection
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/assets/js/jquery.min.js",
            "~/assets/js/bootstrap.min.js",
            "~/assets//js/jquery.blockui.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/css/font-awesome.min.css",
                      "~/assets/css/bootstrap.min.css",
                      "~/assets/css/layout.min.css",
                      "~/assets/css/admin-style.css"));
        }
    }
}
