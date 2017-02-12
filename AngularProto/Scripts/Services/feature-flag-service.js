/*global angular*/

(function () {
    'use strict';
    
	const app = angular.module('app');

	app.factory('FeatureFlagService', function ($http, 
                                                $log,
                                                FeatureFlagTableViewFactory) {
        
        return {
            
            create(featureFlag) {
                return $http.post('/FeatureFlags/Create/', { 
                    viewModel: featureFlag
                });
            },
            
            retrieve() {
                return $http.post('/FeatureFlags/Get/')
                    .then(function (response) {
                        if (response.data) {
                            const flags = [];
                            
                            for (let i = 0; i < response.data.length; i++) {
                                const jsonObj = response.data[i];
                                const flag = FeatureFlagTableViewFactory.buildFromJson(jsonObj);
                                flags.push(flag);
                            }
                            
                            return flags;
                        }
                    }, function (reason) {});
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