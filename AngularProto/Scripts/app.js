(function () {
	var app = angular.module('app', ['ngRoute']);

	app.config(function ($routeProvider, $locationProvider) {
		$routeProvider.when('/', {
			templateUrl: '/Home/Login'
		}).when('/Register', {
			templateUrl: '/Home/Register'
		})
		.when('/Home', {
			templateUrl: '/Tasks/Index'
		})
		.when('/FeatureFlags', {
			templateUrl: '/FeatureFlags/Index'
		})
		.when('/Tasks', {
			templateUrl: '/Tasks/Index'
		})
        .when('/Lists', {
            templateUrl: '/Lists/Index'
        })
		.when('/Terminal', {
			templateUrl: '/Tasks/Index'
		});

		$locationProvider.hashPrefix('');
	});

	app.run(function ($http,
										$rootScope,
										$http,
										UserLogoutService,
										FeatureFlagService) {

		$rootScope.pageFns = {};

		$rootScope.pageFns.logout = function () {
			UserLogoutService.logout().then(function (isSuccessful) {
				if (isSuccessful) {
					$location.path('/');
				}

			}, function (reason) {});
		}

		$rootScope.appData = FeatureFlagService.retrieve()
			.then(function (response) {
				console.log(response.data);
			}, function () {});

	});

}());
