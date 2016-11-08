(function () {
	var app = angular.module('app', ['ngRoute']);

	app.config(function ($routeProvider) {
		$routeProvider.when('/routeOne', {
            templateUrl: '/RoutesDemo/One'
        })
        .when('/routeTwo/:donuts', {
            templateUrl: function (params) {
            	return '/RoutesDemo/Two?donuts=' + params.donuts;
            }
        })
        .when('/routeThree', {
            templateUrl: 'RoutesDemo/Three'
        });
	});
})();