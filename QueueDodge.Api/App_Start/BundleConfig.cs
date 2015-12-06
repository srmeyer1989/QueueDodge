using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Optimization;

namespace QueueDodge
{


    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/vendor/js").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-ui-router.js",
                        "~/Scripts/lodash.js",
                        "~/Scripts/restangular.js",
                        "~/Scripts/moment.js",
                        "~/Scripts/angular-moment.js",
                        "~/Scripts/angular-animate.js",
                        "~/Scripts/angular-ui/ui-bootstrap.js",
                        "~/Scripts/angular-ui/ui-bootstrap-tpls.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundle/app/js")
                .Include("~/app/app.module.js")
                .IncludeDirectory("~/app", "*.js", true));

            //  bundles.Add(new StyleBundle("vendor/styles").Include());
#if DEBUG

            BundleTable.EnableOptimizations = false;
#else
        BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
