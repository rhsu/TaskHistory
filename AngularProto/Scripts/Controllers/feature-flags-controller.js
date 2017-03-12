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
                        $rootScope.appData.flags.push(newFlag);
                        resetForm();
                    }
                }, function () {});
        }

        $scope.pageFns.delete = function (flag) {
          FeatureFlagService.delete(flag.id)
            .then(function (response) {
              const success = response.data;
              if (success) {
                const idx = $scope.pageData.flags.findIndex(function (elem) {
                  return elem.id == flag.id;
                });

                
              }
            }, function () {});
        }

        /***** End Page Function Declarations *****/
        var resetForm = function (newFlag) {
            $scope.formData = {};
        }
	});

}());
