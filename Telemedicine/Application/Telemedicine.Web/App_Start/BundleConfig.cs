using System.Web;
using System.Web.Optimization;

namespace Telemedicine.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                      "~/Scripts/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/highcharts")
                .Include("~/Scripts/highcharts/highcharts.js")
                .Include("~/Scripts/highcharts/exporting.js")
                .Include("~/Scripts/highcharts/highcharts-ng.js"));

            bundles.Add(new ScriptBundle("~/bundles/grid-light")
               .Include("~/Scripts/highcharts/grid-light.js"));

            bundles.Add(new ScriptBundle("~/bundles/dark-unica")
           .Include("~/Scripts/highcharts/dark-unica.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-resource.js")
                .Include("~/Scripts/angular-date-interceptor.js"));

            bundles.Add(new ScriptBundle("~/bundles/ui-angular")
                .Include("~/Scripts/angular-ui/ui-bootstrap-tpls.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                       .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/app/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/controllers")
                .IncludeDirectory("~/app/controllers", "*.js"));

            bundles.Add(new ScriptBundle("~/bundles/factories")
                .IncludeDirectory("~/app/factories", "*.js"));

            bundles.Add(new ScriptBundle("~/bundles/constants")
                .IncludeDirectory("~/app/constants", "*.js"));

            bundles.Add(new ScriptBundle("~/bundles/filters")
               .IncludeDirectory("~/app/filters", "*.js"));

            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/BloggerSans.css")
                .Include("~/Content/site.css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/cerulean.min.css"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#elif !DEBUG 
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}