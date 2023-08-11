/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

    $(document).ready(function () {
        $.getJson("/NHANVIENs/GetData", function (data) {
            var TenTour = [];
            var TongTien = [];


            for (var i = 0; i < data.length; i++) {
                TenTour.push(data[i].name);
                TongTien.push(data[i].count);

            }

            // Data retrieved https://en.wikipedia.org/wiki/List_of_cities_by_average_temperature
            Highcharts.chart('container', {
                chart: {
                    type: 'line'
                },
                title: {
                    text: 'Monthly Average Temperature'
                },
                subtitle: {
                    text: 'Source: ' +
                        '<a href="https://en.wikipedia.org/wiki/List_of_cities_by_average_temperature" ' +
                        'target="_blank">Wikipedia.com</a>'
                },
                xAxis: {
                    categories: TenTour
                  
                },
                yAxis: {
                    title: {
                        text: 'Temperature (°C)'
                    }
                },
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: true
                        },
                        enableMouseTracking: false
                    }
                },
                series: [{
                    name: 'Tổng tiền',
                    data: TongTien
                    
                }]
            });
        });
    });

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

    $(document).ready(function () {
        $.getJson("/NHANVIENsCONTROLLER/GetData", function (data) {
            var TenTour = [];
            var TongTien = [];

            var chartData = [];

            for (var i = 0; i < data.length; i++) {
                var item = data[i];
                chartData.push({
                    name: item.name,
                    y: item.count
                })
            }

            for (var i = 0; i < data.length; i++) {
                TenTour.push(data[i].name);
                TongTien.push(data[i].count);

            }

            // Data retrieved https://en.wikipedia.org/wiki/List_of_cities_by_average_temperature
            Highcharts.chart('container', {
                chart: {
                    type: 'line'
                },
                title: {
                    text: 'Monthly Average Temperature'
                },
                subtitle: {
                    text: 'Source: ' +
                        '<a href="https://en.wikipedia.org/wiki/List_of_cities_by_average_temperature" ' +
                        'target="_blank">Wikipedia.com</a>'
                },
                xAxis: {
                    categories: TenTour
                },
                yAxis: {
                    title: {
                        text: 'Temperature (°C)'
                    }
                },
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: true
                        },
                        enableMouseTracking: false
                    }
                },
                series: [{
                    name: 'Reggane',
                    data: TongTien
                }]
            });
        });
    });

/* END EXTERNAL SOURCE */
