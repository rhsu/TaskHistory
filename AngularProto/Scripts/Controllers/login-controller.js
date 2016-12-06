(function () {
	var app = angular.module('app');

	app.controller('LoginController', function ($scope, UserLoginService) {
		$scope = {
			data : {},
			fns : {}
		};

		$scope.fns.login = function () {
			UserLoginService.login($scope.data.user);
		}
	});

})();