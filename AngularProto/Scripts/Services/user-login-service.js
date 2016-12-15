(function () {
	const app = angular.module('app');

	app.factory('UserLoginService', function ($http) {
		return {

			//logins the user
			promiseLoginUser(loginViewModel) {
				return $http.post('/Authentication/Login', { userLoginViewModel: loginViewModel })
				.then(function (response) {
					success = response.data;
					if (success) {
						//redirect to ....
					}
				}, function (reason) {
					// placeholder here in the future for error handling
				});
			}

		}
	}); 
})();