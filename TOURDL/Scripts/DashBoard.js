//From Below Json result how to set "xAxis-> title" as StudentName
//From Below Json result how to set "xAxis->categories" as AcademicYear 
//From Below Json result how to set "series-> name" as Subject
//From Below Json result how to set "series-> data" as Marks 


var data = [
	{
		"StudentName": "Henry",
		"Subject": "English",
		"Marks": 81,
		"AcademicYear": "2011"
	},
	{
		"StudentName": "Henry",
		"Subject": "English",
		"Marks": 83,
		"AcademicYear": "2012"
	},
	{
		"StudentName": "Henry",
		"Subject": "Mathematics",
		"Marks": 76,
		"AcademicYear": "2011"
	},
	{
		"StudentName": "Henry",
		"Subject": "Mathematics",
		"Marks": 56,
		"AcademicYear": "2012"
	}
]

Highcharts.chart('container', {
	chart: {
		type: 'bar'
	},
	title: {
		text: 'Stack chart'
	},
	xAxis: {
		title: {
			text: 'Student Name - Henry'
		},
		categories: [2011, 2012]
	},
	yAxis: {
		min: 0,
		title: {
			text: 'Marks'
		}
	},
	legend: {
		reversed: true
	},
	plotOptions: {
		series: {
			stacking: 'normal'
			,
			dataLabels: {
				enabled: true,
				color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
			}
		}
	},
	series: [{
		name: 'English',
		data: [81, 83]
	},
	{
		name: 'Mathematics',
		data: [76, 56]
	}
	]
});