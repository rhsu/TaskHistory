(function () {
	const app = angular.module('app');

	app.factory('UserLoginService', function ($http) {
		return {

			promiseLoginUser(loginViewModel) {
				return $http.post('/Authentication/Login', { userLoginViewModel: loginViewModel })
				.then(function (response) {
					return response.data;
				}, function () {});
			},

			promiseLoginAdmin(loginViewModel) {
				return $http.post('/Authentication/AdminLogin', {userLoginViewModel : loginViewModel})
				.then(function (response) {
					return response.data;
				}, function () {});
			}
		}
	});
})();
