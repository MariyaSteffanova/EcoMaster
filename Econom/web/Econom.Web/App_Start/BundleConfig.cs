﻿using System.Web;
using System.Web.Optimization;

namespace Econom.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/material.min.js",
                      "~/Scripts/ripples.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                     "~/Scripts/appStart.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                "~/Content/theme/js/vendor/jquery-2.1.4.min.js",
                "~/Content/theme/js/vendor/bootstrap.min.js",
                "~/Content/theme/js/vendor/vendor.js",
                "~/Content/theme/js/variable.js",
                "~/Content/theme/js/main.js"
                ));

            bundles.Add(new StyleBundle("~/Content/theme").Include(
                "~/Content/theme/css/style.css",
                "~/Content/theme/css/color.css",
                "~/Content/theme/css/title-size.css",
                "~/Content/theme/css/custom.cs"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-material-design.min.css",
                "~/Content/ripples.min.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/register").Include(
                "~/Content/pages/account.css",
                "~/Content/file-upload.css"
                ));

            bundles.Add(new StyleBundle("~/Content/login").Include(
               "~/Content/pages/account.css"
               ));

            bundles.Add(new StyleBundle("~/Content/home").Include(
              "~/Content/font-awesome.min.css",
                "~/Content/pages/home.css"
              ));
        }
    }
}
