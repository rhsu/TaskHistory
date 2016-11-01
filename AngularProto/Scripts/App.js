(function () {
	var app = angular.module('app', ['ngRoute']);

	app.config(function ($routeProvider) {
		$routeProvider.when('/routeOne', {
            templateUrl: 'routesDemo/one'
        })
        .when('/routeTwo', {
            templateUrl: 'routesDemo/two'
        })
        .when('/routeThree', {
            templateUrl: 'routesDemo/three'
        });
	});
})();