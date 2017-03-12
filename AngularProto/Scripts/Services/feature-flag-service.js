/*global angular*/

(function () {
    'use strict';

	const app = angular.module('app');

	app.factory('FeatureFlagService', function ($http) {

        return {

            create(featureFlag) {
                return $http.post('/FeatureFlags/Create/', {
                    viewModel: featureFlag
                });
            },

            retrieve() {
                return $http.post('/FeatureFlags/Get/');
            },

            update(featureFlag) {
                return $http.post('/FeatureFlags/Update/', {
                    viewModel: featureFlag
                });
            },

            delete(id) {
                return $http.post('/FeatureFlags/Delete/', {
                    id: id
                });
            }
        }

	});

}());
