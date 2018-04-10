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
        var info0 = new Highcharts.Chart({
            credits: {
                enabled : false
            },
            exporting: { enabled: false },
            title: {
                text: '',
                x: 0 //center
            },
            //colors: ['#2b908f', '#90ee7e', '#f45b5b', '#7798BF', '#aaeeee', '#ff0066',
            //    '#eeaaee', '#55BF3B', '#DF5353', '#7798BF', '#aaeeee'],
            chart: {
                renderTo: 'analytics',
                backgroundColor: null,
                plotBackgroundColor: 'none',
            },
            //subtitle: {
            //    text: 'в 2016 году',
            //    x: 0
            //},
            xAxis: {
                categories: ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь',
                    'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'],
                lineColor: '#ffffff',
                tickColor: '#ffffff',
                labels: {
                    style: {
                        color: '#ffffff',
                    }
                },
                title: {
                    style: {
                        color: '#ffffff',
                    }
                },
            },
            yAxis: {
                title: {
                    // enabled: false,
                    text: 'Произведено, ед.',
                    style: {
                        color: '#ffffff',
                    }
                },
                plotLines: [{
                    value: 0,
                    width: 1,
                    color: '#ffffff'
                }],
                lineColor: '#ffffff',
                tickColor: '#ffffff',
                labels: {
                    // enabled: false,
                    style: {
                        color: '#ffffff',
                    }
                },
            },
            //tooltip: {
            //    formatter: function () {
            //        return this.x + ': ' + this.point.y + ' руб.';
            //    },
            //    valueSuffix: ' руб.'
            //},
            legend: {
                enabled: true,
                //align: 'right',
                //layout: 'vertical',
                //verticalAlign: 'middle',
                borderWidth: 0,
                itemStyle: {
                    color: '#ffffff',
                }
            },
            //series: [{
            //    name: '',
            //    data: data
            //}]
            series: [{
                name: 'По плану',
                data: [105000, 100000, 100000, 98000, 95000, 94000, 98000, 100000, 100000, 100000, 100000, 100000],
                color: '#2b908f'
            },{
                name: 'Выполнено',
                data: [110000, 105000, 100000, 95000, 90000, 91000, 95000, 98000, 101000, 104000, 103000, 101000],
                color: '#90ee7e'
            }],
        });

        var info1 = new Highcharts.Chart({
            credits: {
                enabled: false
            },
            exporting: { enabled: false },
            title: {
                text: '',
                x: 0 //center
            },
            //colors: ['#2b908f', '#90ee7e', '#f45b5b', '#7798BF', '#aaeeee', '#ff0066',
            //    '#eeaaee', '#55BF3B', '#DF5353', '#7798BF', '#aaeeee'],
            chart: {
                renderTo: 'analytics-year',
                backgroundColor: null,
                plotBackgroundColor: 'none',
            },
            //subtitle: {
            //    text: 'в 2016 году',
            //    x: 0
            //},
            xAxis: {
                categories: ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь',
                    'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'],
                lineColor: '#ffffff',
                tickColor: '#ffffff',
                labels: {
                    style: {
                        color: '#ffffff',
                    }
                },
                title: {
                    style: {
                        color: '#ffffff',
                    }
                },
            },
            yAxis: {
                title: {
                    // enabled: false,
                    text: 'Произведено, ед.',
                    style: {
                        color: '#ffffff',
                    }
                },
                plotLines: [{
                    value: 0,
                    width: 1,
                    color: '#ffffff'
                }],
                lineColor: '#ffffff',
                tickColor: '#ffffff',
                labels: {
                    // enabled: false,
                    style: {
                        color: '#ffffff',
                    }
                },
            },
            //tooltip: {
            //    formatter: function () {
            //        return this.x + ': ' + this.point.y + ' руб.';
            //    },
            //    valueSuffix: ' руб.'
            //},
            legend: {
                enabled: true,
                //align: 'right',
                //layout: 'vertical',
                //verticalAlign: 'middle',
                borderWidth: 0,
                itemStyle: {
                    color: '#ffffff',
                }
            },
            //series: [{
            //    name: '',
            //    data: data
            //}]
            series: [{
                name: '2018г.',
                data: [125000, 130000, 115000, 110000, 100000, 110000],
                color: '#f45b5b'
            }, {
                name: '2017г.',
                data: [110000, 105000, 100000, 95000, 90000, 91000, 95000, 98000, 101000, 104000, 103000, 101000],
                color: '#7798BF'
            }],
        });

        var info = new Highcharts.Chart({
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

        var info3 = new Highcharts.Chart({
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