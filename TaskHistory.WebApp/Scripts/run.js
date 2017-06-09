(function () {

  const app = angular.module('app');

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

})();
