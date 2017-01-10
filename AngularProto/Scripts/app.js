(function () {
	var app = angular.module('app', ['ngRoute']);

	app.config(function ($routeProvider) {
		$routeProvider.when('/', {
			templateUrl: '/Home/Login'
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

	// TODO put me in a separate file
	app.controller('AppController', function ($scope, $location, UserLogoutService) {
		$scope.pageFns = {};

		$scope.pageFns.logout = function () {
		
			UserLogoutService.logout().then(function (isSuccessful) {
				if (isSuccessful) {
					$location.path('/');
				}

			}, function (reason) {
				//TODO placeholder for error handling
			});	

		}
	});
})();