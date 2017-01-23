/*global angular*/
/*jshint esversion: 6 */

(function () {
    'use strict';
    
	const app = angular.module('app');

	app.controller('FeatureFlagsController', function ($scope, $log, FeatureFlagService) {
        $scope.pageData = {};
        $scope.pageData.flags = [];
        
        $scope.formData = {};
        
        for (let i = 0; i < 5; i++) {
            $scope.pageData.flags.push({id: 1, name: 'hello', value: i});
        }
        
        FeatureFlagService.retrieve().then(function (response) {
            /*$log.info(response.data);*/
            if (response.data) {
                ///
            }
            
        }, function (reason) {});
        
        $scope.pageFns = {};
        $scope.pageFns.createFlag = function () {
            FeatureFlagService.create($scope.formData)
                .then(function (response) {
                    if (response.data) {
                        //reset the form
                        // push to collection
                        //$scope.pageData.flags.push
                    }
                }, function (reason) {});
        }
	});

}());