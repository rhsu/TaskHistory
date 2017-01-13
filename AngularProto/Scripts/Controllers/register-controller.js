(function () {
	const app = angular.module('app');

	app.controller('RegisterController', function ($scope, $location, UserRegisterService) {
		$scope.formData = {};

		$scope.pageState = {};
		$scope.pageState.invalidUsername = false;

		$scope.pageFns = {};
		$scope.pageFns.register = function () {
			console.log($scope.formData);

			UserRegisterService.promiseRegisterUser($scope.formData)
			.then(function (response) {

				if (response) {
					//TODO: how does $location do query strings?
					$location.path('/');
				} else {
					$scope.pageState.invalidUsername = true;
				}
			}, function (reason) {
			});
		}
	});
})();