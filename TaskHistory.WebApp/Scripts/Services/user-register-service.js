(function () {
	const app = angular.module('app');

	app.factory('UserRegisterService', function ($http) {
		return {

			promiseRegisterUser(userRegisterViewModel) {
				return $http.post('/Authentication/Register', { userRegisterViewModel : userRegisterViewModel })
				.then(function (response) {
					return response.data;
				}, function (reason) {
					// placeholder for error handling
				});
			}
		}
	});
})();
