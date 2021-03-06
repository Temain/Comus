﻿var ReportViewModel = function (app, dataModel) {
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
                renderTo: 'analytics-2017',
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
                    text: 'Прибыль, тыс. руб.',
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

        var info2 = new Highcharts.Chart({
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
                renderTo: 'analytics-2018',
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
                    text: 'Прибыль, тыс. руб.',
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
                data: [110000, 105000, 105000, 100000, 95000, 100000, 105000, 100000, 105000, 110000, 100000, 105000],
                color: '#2b908f'
            }, {
                name: 'Выполнено',
                data: [115000, 110000, 110000, 105000, 95000, 100000],
                color: '#f45b5b'
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
                    text: 'Прибыль, тыс. руб.',
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
                data: [115000, 110000, 110000, 105000, 95000, 100000],
                color: '#f45b5b'
            }, {
                name: '2017г.',
                data: [110000, 105000, 100000, 95000, 90000, 91000, 95000, 98000, 101000, 104000, 103000, 101000],
                color: '#90ee7e'
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

        Highcharts.chart('analitycs-advert', {
            data: {
                table: 'datatable'
            },
            chart: {
                type: 'column',
                // margin: [0, 0, 0, 0],
                backgroundColor: null,
                plotBackgroundColor: 'none',
            },
            title: {
                text: ''
            },
            credits: {
                enabled: false
            },
            exporting: { enabled: false },
            xAxis: {
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
                allowDecimals: false,
                title: {
                    text: 'Units'
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
            tooltip: {
                formatter: function () {
                    return '<b>' + this.series.name + '</b><br/>' +
                        this.point.y + ' ' + this.point.name.toLowerCase();
                }
            },
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
        });

        Highcharts.chart('sales-funnel', {
            credits: {
                enabled: false
            },
            chart: {
                type: 'funnel',
                marginRight: 100,
                backgroundColor: null,
                plotBackgroundColor: 'none',
            },
            exporting: { enabled: false },
            title: {
                text: '',
                x: -50
            },
            plotOptions: {
                series: {
                    dataLabels: {
                        enabled: true,
                        format: '<b>{point.name}</b> ({point.y:,.0f})',
                        color: '#ffffff', // (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black',
                        softConnector: true
                    },
                    neckWidth: '30%',
                    neckHeight: '25%',
                    color: '#ffffff'
                    //-- Other available options
                    // height: pixels or percent
                    // width: pixels or percent
                }
            },
            legend: {
                enabled: false,
                borderWidth: 0,
                itemStyle: {
                    color: '#ffffff',
                }
            },
            series: [{
                name: 'Unique users',
                data: [
                    ['Получено заявок', 256],
                    ['Обработано заявок', 152],
                    ['Сделок', 21],
                    ['Получили товар', 19]
                ]
            }]
        });

        //var info3 = new Highcharts.Chart({
        //    chart: {
        //        renderTo: 'space',
        //        margin: [0, 0, 0, 0],
        //        backgroundColor: null,
        //        plotBackgroundColor: 'none',

        //    },

        //    title: {
        //        text: null
        //    },

        //    tooltip: {
        //        formatter: function () {
        //            return this.point.name + ': ' + this.y + ' %';

        //        }
        //    },
        //    series: [
        //        {
        //            borderWidth: 2,
        //            borderColor: '#F1F3EB',
        //            shadow: false,
        //            type: 'pie',
        //            name: 'SiteInfo',
        //            innerSize: '65%',
        //            data: [
        //                { name: 'Used', y: 65.0, color: '#fa1d2d' },
        //                { name: 'Rest', y: 35.0, color: '#3d3d3d' }
        //            ],
        //            dataLabels: {
        //                enabled: false,
        //                color: '#000000',
        //                connectorColor: '#000000'
        //            }
        //        }]
        //});

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