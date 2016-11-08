(function () {
	var app = angular.module('app', ['ngRoute']);

	app.config(function ($routeProvider) {
		$routeProvider.when('/Home', {
			templateUrl: ''
		})
		.when('/Tasks', {
			templateUrl: ''
		})
		.when('/Terminal', {
			templateUrl: ''
		});
	});

})();