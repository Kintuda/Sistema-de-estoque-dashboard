using System.Web;
using System.Web.Optimization;

namespace enzo_estoqueV1
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/dashboard").Include(
                        "~/Scripts/black-dashboard.min",
                        "~/Scripts/black-dashboard.js.map",
                        "~/Scripts/black-dashboard.js",
                        "~/Scripts/perfect-scrollbar.jquery.min.js",
                        "~/Scripts/demo.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/black-dashboard.css",
                      "~/Content/black-dashboard.min",
                      "~/Content/main.css",
                      "~/Content/black-dashboard.css?v=1.0.0",
                      "~/Content/nucleo-icons.css",
                      "~/Content/site.css"));
        }
    }
}

