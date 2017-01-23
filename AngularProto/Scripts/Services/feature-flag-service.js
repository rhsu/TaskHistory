(function () {
	const app = angular.module('app');

	app.factory('FeatureFlagService', function ($http) {
        
        return {
            getFeatureFlags() {
                return $http.post('FeatureFlags')
            },
        }

	}
})();