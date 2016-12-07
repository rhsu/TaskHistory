(function () {
	console.log('this is registered');
	var app = angular.module('app');

	app.controller('LoginController', function ($scope) {

		$scope.formData = {};
		$scope.formData.user = '';
		$scope.formData.password = '';

		/*$scope.fns.login = function () {
			/*UserLoginService.login($scope.formData).then(function (response) {
				
			}, function (reason) {
				
			});
		};*/
	});

})();