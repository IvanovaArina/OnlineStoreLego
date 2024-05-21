using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebApplication.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
           
            // Template style
            bundles.Add(new StyleBundle("~/bundles/bootstrap/assets/css").Include(
            "~/assets/css/vendor/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/font-awesome/assets/css").Include(
            "~/assets/css/vendor/font-awesome.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/slick-theme/css").Include(
            "~/assets/css/vendor/slick-theme.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/aksVideoPlayer/css").Include(
            "~/assets/css/vendor/aksVideoPlayer.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/slick/css").Include(
           "~/assets/css/vendor/slick.css"));

            bundles.Add(new StyleBundle("~/bundles/app").Include(
            "~/assets/css/app.css", new CssRewriteUrlTransform()));

            // JavaScript Bundles
            bundles.Add(new ScriptBundle("~/bundles/vendor/js").Include(
                "~/assets/js/vendor/jquery-3.6.3.min.js",
                "~/assets/js/vendor/bootstrap.min.js",
                "~/assets/js/vendor/slick.min.js",
                "~/assets/js/vendor/jquery-appear.js",
                "~/assets/js/vendor/jquery-validator.js",
                "~/assets/js/vendor/aksVideoPlayer.js",
                "~/assets/js/app.js"));
            bundles.Add(new ScriptBundle("~/bundles/vendor/min").Include(
                "~/assets/js/vendor.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app/js").Include(
                "~/assets/js/app.min.js"));

            // Включение оптимизации
            BundleTable.EnableOptimizations = true;
        }
    }
}