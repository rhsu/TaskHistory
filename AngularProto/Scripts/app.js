(function () {
	var app = angular.module('app', ['ngRoute']);

	app.config(function ($routeProvider) {
		$routeProvider.when('/', {
			templateUrl: '/Home/Login'
		}).when('/Register', {
			templateUrl: '/Home/Register'
		})
		.when('/Home', {
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