(function () {
	var app = angular.module('app', ['ngRoute']);

	app.config(function ($routeProvider) {
		$routeProvider.when('/routeOne', {
            templateUrl: 'RoutesDemo/One'
        })
        .when('/routeTwo', {
            templateUrl: 'RoutesDemo/Two'
        })
        .when('/routeThree', {
            templateUrl: 'RoutesDemo/Three'
        });
	});
})();