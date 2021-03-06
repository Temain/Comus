﻿using System.Web.Optimization;

namespace Comus.Web
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.mapping-latest.js",
                "~/Scripts/knockout.validation.js",
                "~/Scripts/knockout.bindings.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/underscore.min.js",
                "~/Scripts/moment-with-locales.js",
                "~/Scripts/sammy-{version}.js",
                "~/Scripts/app/common.js",
                "~/Scripts/app/app.datamodel.js",
                "~/Scripts/app/app.viewmodel.js",
                "~/Scripts/app/sale.viewmodel.js",
                "~/Scripts/app/product.viewmodel.js",
                "~/Scripts/app/employee.viewmodel.js",
                "~/Scripts/app/client.viewmodel.js",
                "~/Scripts/app/clientRequest.viewmodel.js",
                "~/Scripts/app/report.viewmodel.js",
                "~/Scripts/app/call.viewmodel.js",
                "~/Scripts/app/_run.js",
                "~/Scripts/bootstrap-datetimepicker.js",
                "~/Scripts/lineandbars.js",
                //"~/Scripts/dash-charts.js",
                "~/Scripts/gauge.js",
                "~/Scripts/noty/jquery.noty.js",
                "~/Scripts/noty/layouts/top.js",
                "~/Scripts/noty/layouts/topLeft.js",
                "~/Scripts/noty/layouts/topRight.js",
                "~/Scripts/noty/layouts/topCenter.js",
                "~/Scripts/noty/themes/default.js",
                "~/Scripts/jquery.flexslider.js",
                "~/Scripts/admin.js",
                "~/Scripts/bootstrap3-typeahead.min.js",
                "~/Scripts/alert.js"));

            bundles.Add(new ScriptBundle("~/bundles/highcharts").Include(
                "~/Scripts/highcharts/highcharts.js",
                "~/Scripts/highcharts/highcharts-more.js",
                "~/Scripts/highcharts/modules/data.js",
                "~/Scripts/highcharts/modules/exporting.js",
                "~/Scripts/highcharts/modules/funnel.js"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство построения на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/main.css",
                "~/Content/font-style.css",
                "~/Content/flexslider.css",
                "~/Content/font-awesome.min.css",
                "~/Content/bootstrap-datetimepicker.css"));

            bundles.Add(new StyleBundle("~/Content/login").Include(
               "~/Content/bootstrap.css",
               "~/Content/font-awesome.min.css",
               "~/Content/bootstrap-datetimepicker.css",
               "~/Content/login.css"));

            bundles.Add(new StyleBundle("~/Content/table").Include(
               "~/Content/bootstrap.css",
               "~/Content/font-awesome.min.css",
               "~/Content/bootstrap-datetimepicker.css",
               "~/Content/table.css"));
        }
    }
}