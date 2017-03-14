(function () {
	const app = angular.module('app');

	app.controller('LoginController', function ($scope, UserLoginService, $location) {

		$scope.formData = {};
		$scope.formData.username = '';
		$scope.formData.password = '';

		$scope.pageState = {};
		$scope.pageState.isRegisterSuccessful = $location.search().isRegisterSuccessful;

		$scope.fns = {};
		$scope.fns.login = function () {
			UserLoginService.promiseLoginUser($scope.formData)
				.then(function (response) {
					if (response) {
						$location.path('/Tasks');
					} else {
						// TODO what do I do here if user doesn't login successfully
						// Some suggestions maybe all or none.
						// 1. Increase failed login attempts and eventually lock the user
						// 2. kill the session
						// 3. perform a FormsAuthentication.deauthenticate
					}
				}, function (reason) {

				});
		};
	});
})();