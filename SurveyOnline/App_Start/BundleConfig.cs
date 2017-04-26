using System.Web;
using System.Web.Optimization;

namespace SurveyOnline
{
    public class BundleConfig
    {
        
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jscustomize").Include(
                        "~/Scripts/js-frontend/Home.js",
                        "~/Scripts/js-frontend/customize.js",
                        "~/Scripts/js-frontend/EditQuestion_MulChoice.js",
                        "~/Scripts/js-frontend/Title_Des_Design.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/js-frontend/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/js-frontend/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/js-frontend/bootstrap.js",
                      "~/Scripts/jquery.dataTables.min.js",
                      "~/Scripts/dataTables.bootstrap.js",
                      "~/Scripts/js-frontend/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css-frontend/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/css-frontend/material-design-iconic-font.min.css",
                      "~/Content/css-frontend/header.css",
                       "~/Content/sss-frontend/social-button.css",
                       "~/Content/css-frontend/main.css",
                      "~/Content/css-frontend/site.css"));
        }
    }
}
