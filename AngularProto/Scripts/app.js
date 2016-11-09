(function () {
	var app = angular.module('app', ['ngRoute']);

	app.config(function ($routeProvider) {
		$routeProvider.when('/Home', {
			templateUrl: '/Tasks/Index'
		})
		.when('/Tasks', {
			templateUrl: '/Tasks/Index'
		})
		.when('/Terminal', {
			templateUrl: '/Tasks/Index'
		});
	});
})();