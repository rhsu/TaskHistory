/*global angular*/
/*jshint esversion: 6 */

(function () {
    'use strict';

	const app = angular.module('app');

	app.controller('FeatureFlagsController', function ($scope,
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

        $scope.pageFns.refresh = function () {
            FeatureFlagService.retrieve().then(function (response) {
                const data = response.data;
                if (data) {
                    for (let i = 0; i < data.length; i++) {
                        const newFlag = FeatureFlagTableViewFactory.buildFromJson(data[i]);
                        $scope.pageData.flags.push(newFlag);
                    }
                }

            }, function (reason) {});
        }

        $scope.pageFns.createFlag = function () {
            FeatureFlagService.create($scope.formData)
                .then(function (response) {
                    var data = response.data;
                    if (data) {
                        const newFlag = FeatureFlagTableViewFactory.buildFromJson(data);
                        $scope.pageData.flags.push(newFlag);
                        resetForm();
                    }
                }, function (reason) {});
        }
        /***** End Page Function Declarations *****/

        $scope.pageFns.refresh();

        var resetForm = function (newFlag) {
            $scope.formData = {};
        }
	});

}());
