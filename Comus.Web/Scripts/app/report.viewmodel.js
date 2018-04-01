var ReportViewModel = function (app, dataModel) {
    var self = this;

    Sammy(function () {
        this.get('#reports', function () {
            app.markLinkAsActive('report');
            var year = 2016;

            $.ajax({
                method: 'get',
                url: '/api/Sale/ChartData/2016',
                contentType: "application/json; charset=utf-8",
                headers: {
                    'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
                },
                success: function (response) {
                    app.view(self);
                    self.showChart(response);
                }
            });
        });

        this.get('/', function () { this.app.runRoute('get', '#reports') });
    });

    self.showChart = function(data) {
        //$('#chart').highcharts({
        //    credits: {
        //        enabled : false
        //    },
        //    title: {
        //        text: 'Продажи ОАО АТМ-Кубань',
        //        x: 0 //center
        //    },
        //    subtitle: {
        //        text: 'в 2016 году',
        //        x: 0
        //    },
        //    xAxis: {
        //        categories: ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь',
        //            'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь']
        //    },
        //    yAxis: {
        //        title: {
        //            text: 'Сумма, руб.'
        //        },
        //        plotLines: [{
        //            value: 0,
        //            width: 1,
        //            color: '#808080'
        //        }]
        //    },
        //    tooltip: {
        //        formatter: function () {
        //            return this.x + ': ' + this.point.y + ' руб.';
        //        },
        //        valueSuffix: ' руб.'
        //    },
        //    legend: {
        //        enabled: false
        //    },
        //    series: [{
        //        name: '',
        //        data: data
        //    }]
        //});

        info = new Highcharts.Chart({
            chart: {
                renderTo: 'load',
                margin: [0, 0, 0, 0],
                backgroundColor: null,
                plotBackgroundColor: 'none',

            },
            credits: {
                enabled : false
            },
            exporting: { enabled: false },
            legend: {
                enabled: false
            },
            title: {
                text: null
            },

            tooltip: {
                formatter: function () {
                    return this.point.name + ': ' + this.y + ' %';

                }
            },
            series: [
                {
                    borderWidth: 2,
                    borderColor: '#F1F3EB',
                    shadow: false,
                    type: 'pie',
                    name: 'Income',
                    innerSize: '65%',
                    data: [
                        { name: 'Выполнение плана', y: 85.0, color: '#b2c831' },
                        { name: 'Отставание от плана', y: 15.0, color: 'red' }
                    ],
                    dataLabels: {
                        enabled: false,
                        color: '#000000',
                        connectorColor: '#000000'
                    }
                }]
        });

        info = new Highcharts.Chart({
            chart: {
                renderTo: 'space',
                margin: [0, 0, 0, 0],
                backgroundColor: null,
                plotBackgroundColor: 'none',

            },

            title: {
                text: null
            },

            tooltip: {
                formatter: function () {
                    return this.point.name + ': ' + this.y + ' %';

                }
            },
            series: [
                {
                    borderWidth: 2,
                    borderColor: '#F1F3EB',
                    shadow: false,
                    type: 'pie',
                    name: 'SiteInfo',
                    innerSize: '65%',
                    data: [
                        { name: 'Used', y: 65.0, color: '#fa1d2d' },
                        { name: 'Rest', y: 35.0, color: '#3d3d3d' }
                    ],
                    dataLabels: {
                        enabled: false,
                        color: '#000000',
                        connectorColor: '#000000'
                    }
                }]
        });

        $("#btn-blog-next").click(function () {
            $('#blogCarousel').carousel('next')
        });
        $("#btn-blog-prev").click(function () {
            $('#blogCarousel').carousel('prev')
        });

        $("#btn-client-next").click(function () {
            $('#clientCarousel').carousel('next')
        });
        $("#btn-client-prev").click(function () {
            $('#clientCarousel').carousel('prev')
        });

        $('.flexslider').flexslider({
            animation: "slide",
            slideshow: true,
            start: function (slider) {
                $('body').removeClass('loading');
            }
        });
    }

    return self;
}
 
app.addViewModel({
    name: "Report",
    bindingMemberName: "reports",
    factory: ReportViewModel
});