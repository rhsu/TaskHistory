(function () {
	var app = angular.module('app');

	app.controller('LoginController', function ($scope, UserLoginService) {

		$scope.formData = {};
		$scope.formData.user = '';
		$scope.formData.password = '';

		$scope.fns = {};
		$scope.fns.login = function () {
			UserLoginService.promiseLoginUser();
		};
	});
})();