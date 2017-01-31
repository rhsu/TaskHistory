(function () {
	const app = angular.module('app');

	app.controller('RegisterController', function ($scope, $location, UserRegisterService) {
		$scope.formData = {};

		$scope.pageState = {};
		$scope.pageState.invalidUsername = false;

		$scope.pageFns = {};
		$scope.pageFns.register = function () {

			UserRegisterService.promiseRegisterUser($scope.formData)
			.then(function (response) {

				if (response) {
					$location.path('/').search({isRegisterSuccessful: true});
				} else {
					$scope.pageState.invalidUsername = true;
				}
			}, function (reason) {
			});

		}
	});
})();