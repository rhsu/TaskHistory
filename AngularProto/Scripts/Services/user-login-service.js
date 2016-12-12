(function () {
	var app = angular.module('app');

	app.factory('UserLoginService', function ($http) {
		return {
			test() {
				console.log('worked');
			},

			promiseLoginUser(loginViewModel) {
				console.log(loginViewModel);

				return $http.post('/Authentication/Login', { userLoginViewModel: loginViewModel }).then(function (response) {
					console.log(response);
				}, function (reason) {
					// placeholder here in the future for error handling
				});
			}
		}
	}); 
})();