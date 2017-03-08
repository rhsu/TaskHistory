/*global angular*/
/*jshint esversion: 6 */

(function () {
    'use strict';

	const app = angular.module('app');

	app.controller('FeatureFlagsController', function ($scope,
                                                     $rootScope,
                                                     $log,
                                                     FeatureFlagService,
                                                     FeatureFlagTableViewFactory) {


        /***** PageData Declarations *****/
        $scope.pageData = {};
        $scope.pageData.flags = [];
        /***** End Page Data Declarations *****/

        /***** Form Data Declaration *****/
        $scope.formData = {};
        /***** End Form Data Declaration *****/

        /***** Page Function Delcarations *****/
        $scope.pageFns = {};

        $scope.pageFns.createFlag = function () {
            FeatureFlagService.create($scope.formData)
                .then(function (response) {
                    var data = response.data;
                    if (data) {
                        const newFlag = FeatureFlagTableViewFactory.buildFromJson(data);
                        //$scope.pageData.flags.push(newFlag);
                        $rootScope.appData.flags.push(newFlag);
                        resetForm();
                    }
                }, function (reason) {});
        }
        /***** End Page Function Declarations *****/

        $rootScope.appFns.refreshFeatureFlags();

        var resetForm = function (newFlag) {
            $scope.formData = {};
        }
	});

}());
