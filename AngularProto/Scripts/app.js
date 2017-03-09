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
		.when('/Admin', {
			templateUrl: '/Admin/Index'
		})
		.when('/Terminal', {
			templateUrl: '/Tasks/Index'
		});

		$locationProvider.hashPrefix('');
	});

	app.run(function ($http,
										$rootScope,
										$http,
										$location,
										UserLogoutService,
										FeatureFlagService,
										FeatureFlagTableViewFactory) {

		$rootScope.appFns = {};
		$rootScope.appData = {};
		$rootScope.appData.flags = [];

		$rootScope.appFns.logout = function () {
			UserLogoutService.logout().then(function (isSuccessful) {
				if (isSuccessful) {
					$location.path('/');
				}

			}, function (reason) {});
		}

		$rootScope.appFns.refreshFeatureFlags = function () {
			FeatureFlagService.retrieve().then(function (response) {
				const data = response.data;
				if (data) {
						for (let i = 0; i < data.length; i++) {
								const newFlag = FeatureFlagTableViewFactory.buildFromJson(data[i]);
								$rootScope.appData.flags.push(newFlag);
						}
				}
			}, function () {});
		}

		$rootScope.appFns.refreshFeatureFlags();
	});

}());
