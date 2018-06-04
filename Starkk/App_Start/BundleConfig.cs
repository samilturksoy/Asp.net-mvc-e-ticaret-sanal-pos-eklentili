using System.Web;
using System.Web.Optimization;

namespace Starkk
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //starkmss css
            bundles.Add(new StyleBundle("~/Content/starkcss").Include(
                            "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                            "~/Content/vendor/font-awesome/css/font-awesome.min.css",
                            "~/Content/vendor/animate/animate.min.css",
                            "~/Content/vendor/simple-line-icons/css/simple-line-icons.min.css",
                            "~/Content/vendor/owl.carousel/assets/owl.carousel.min.css",
                            "~/Content/vendor/owl.carousel/assets/owl.theme.default.min.css",
                            "~/Content/vendor/magnific-popup/magnific-popup.min.css",
                            "~/Content/css/theme.css",
                            "~/Content/css/theme-elements.css",
                            "~/Content/css/theme-blog.css",
                            "~/Content/css/theme-shop.css",
                            "~/Content/vendor/rs-plugin/css/settings.css",
                            "~/Content/vendor/rs-plugin/css/layers.css",
                            "~/Content/vendor/rs-plugin/css/navigation.css",
                            "~/Content/vendor/circle-flip-slideshow/css/component.css",
                            "~/Content/css/skins/default.css",
                            "~/Content/css/custom.css",
                            "~/Content/css/animate.min.css"
                         ));
            bundles.Add(new StyleBundle("~/Content/starkadmin").Include(
                           "~/Areas/Admin/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
                           "~/Areas/Admin/Content/bower_components/font-awesome/css/font-awesome.min.css",
                           "~/Areas/Admin/Content/bower_components/Ionicons/css/ionicons.min.css",
                           "~/Areas/Admin/Content/dist/css/AdminLTE.min.css",
                           "~/Areas/Admin/Content/dist/css/skins/_all-skins.min.css",
                           "~/Areas/Admin/Content/bower_components/morris.js/morris.css",
                           "~/Areas/Admin/Content/bower_components/jvectormap/jquery-jvectormap.css",
                           "~/Areas/Admin/Content/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                           "~/Areas/Admin/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                           "~/Areas/Admin/Content/bower_components/bootstrap-daterangepicker/daterangepicker.css"
                        ));

            //starkmss js
            bundles.Add(new ScriptBundle("~/bundles/starkjs").Include(
                      "~/Content/vendor/jquery/jquery.min.js",
                      "~/Content/vendor/jquery.appear/jquery.appear.min.js",
                      "~/Content/vendor/jquery.easing/jquery.easing.min.js",
                      "~/Content/vendor/jquery-cookie/jquery-cookie.min.js",
                      "~/Content/vendor/popper/umd/popper.min.js",
                      "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                      "~/Content/vendor/common/common.min.js",
                      "~/Content/vendor/jquery.validation/jquery.validation.min.js",
                      "~/Content/vendor/jquery.easy-pie-chart/jquery.easy-pie-chart.min.js",
                      "~/Content/vendor/jquery.gmap/jquery.gmap.min.js",
                      "~/Content/vendor/jquery.lazyload/jquery.lazyload.min.js",
                      "~/Content/vendor/isotope/jquery.isotope.min.js",
                      "~/Content/vendor/owl.carousel/owl.carousel.min.js",
                      "~/Content/vendor/magnific-popup/jquery.magnific-popup.min.js",
                      "~/Content/vendor/vide/vide.min.js",
                      "~/Content/js/theme.js",
                      "~/Content/vendor/rs-plugin/js/jquery.themepunch.tools.min.js",
                      "~/Content/vendor/rs-plugin/js/jquery.themepunch.revolution.min.js",
                      "~/Content/vendor/circle-flip-slideshow/js/jquery.flipshow.min.js",
                      "~/Content/js/views/view.home.js",
                      "~/Content/js/custom.js",
                      "~/Content/js/jquery.touchSwipe.min.js",
                      "~/Content/js/responsive_bootstrap_carousel.js",
                      "~/Content/js/theme.init.js"));
            //starkadmin js
            bundles.Add(new ScriptBundle("~/bundles/starkadminjs").Include(
                      "~/Areas/Admin/Content/bower_components/jquery/dist/jquery.min.js",
                      "~/Areas/Admin/Content/bower_components/jquery-ui/jquery-ui.min.js",
                      "~/Areas/Admin/Content/bower_components/bootstrap/dist/js/bootstrap.min.js",

                      "~/Areas/Admin/Content/bower_components/datatables.net/js/jquery.dataTables.min.js",
                      "~/Areas/Admin/Content/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js",
                      "~/Areas/Admin/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",

                      "~/Areas/Admin/Content/bower_components/raphael/raphael.min.js",
                      "~/Areas/Admin/Content/bower_components/morris.js/morris.min.js",
                      "~/Areas/Admin/Content/bower_components/jquery-sparkline/dist/jquery.sparkline.min.js",
                      "~/Areas/Admin/Content/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                      "~/Areas/Admin/Content/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                      "~/Areas/Admin/Content/bower_components/jquery-knob/dist/jquery.knob.min.js",
                      "~/Areas/Admin/Content/bower_components/moment/min/moment.min.js",
                      "~/Areas/Admin/Content/bower_components/bootstrap-daterangepicker/daterangepicker.js",
                      "~/Areas/Admin/Content/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                      "~/Areas/Admin/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                      "~/Areas/Admin/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                      "~/Areas/Admin/Content/bower_components/fastclick/lib/fastclick.js",
                      "~/Areas/Admin/Content/dist/js/adminlte.min.js",
                      "~/Areas/Admin/Content/dist/js/pages/dashboard.js",
                      "~/Areas/Admin/Content/dist/js/demo.js"

                      ));
        }
    }
}
