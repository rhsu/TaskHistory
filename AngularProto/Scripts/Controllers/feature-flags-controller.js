/*global angular*/
/*jshint esversion: 6 */

(function () {
    'use strict';
    
	const app = angular.module('app');

	app.controller('FeatureFlagsController', function ($scope, 
                                                       $log, 
                                                       FeatureFlagService) {
        $scope.pageData = {};
        $scope.pageData.flags = [];
        
        $scope.formData = {};
        
        FeatureFlagService.retrieve().then(function (response) {
            
            for (let i = 0; i < response.length; i++) {
                $scope.pageData.flags.push(response[i]);
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