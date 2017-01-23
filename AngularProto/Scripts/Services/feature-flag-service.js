/*global angular*/

(function () {
    'use strict';
    
	const app = angular.module('app');

	app.factory('FeatureFlagService', function ($http) {
        
        return {
            
            create(featureFlag) {
                return $http.post('/FeatureFlags/Create/', { 
                    name: featureFlag.name,
                    value: featureFlag.value
                });
            },
            
            retrieve() {
                return $http.post('/FeatureFlags/Get/');
            },
            
            update(featureFlag) {
                return $http.post('/FeatureFlags/Update/', {
                   id: featureFlag.id,
                    name: featureFlag.name,
                    value: featureFlag.value
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