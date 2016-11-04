(function () {
	var app = angular.module('app');

	app.controller('AppController', function ($scope, DummyService) {
		$scope.test = 'Hello World';

		$scope.clickMe = function () {
			DummyService.getData();
		}

		$scope.postMe = function () {
			DummyService.postData();
		}
	});
})();