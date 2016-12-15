(function () {
	const app = angular.module('app');

	app.controller('LoginController', function ($scope, UserLoginService) {

		$scope.formData = {};
		$scope.formData.username = '';
		$scope.formData.password = '';

		$scope.fns = {};
		$scope.fns.login = function () {
			UserLoginService.promiseLoginUser($scope.formData);
		};
	});
})();