using System.Web;
using System.Web.Optimization;

namespace HomeUser
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/allScripts").Include(                          
                          "~/Scripts/index.js",
                          "~/angular-app/app.core.js",
                          "~/angular-app/app.service.js",
                          "~/angular-app/app.directive.js",
                          "~/angular-app/app.routes.js",                         
                          "~/angular-app/directive/commonDirective.js",                               
                          "~/angular-app/Services/userManagementService.js",                          
                          "~/angular-app/Services/CommonService.js",                          
                        "~/angular-app/Controllers/HomePage/homePageController.js",                     
                        "~/Angular-app/app.js",
                        "~/Scripts/DropDownJS.js"                            
                     ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css",
                "~/Content/bootstrap.css",
                "~/Content/toaster.css",
                "~/Content/angular.datatables/dataTables.bootstrap.min.css",
                "~/Content/css/angular-toastr.min.css",
                "~/Content/ui-bootstrap-csp.css"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/css/DropDownStylesheet.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}