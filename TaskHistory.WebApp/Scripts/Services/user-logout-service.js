(function () {

	const app = angular.module('app');

	app.factory('UserLogoutService', function ($http) {

		return {

			logout(logoutViewModel) {
				return $http.post('/Authentication/Logout')
				.then(function (response) {
					return response.data;
				}, function () {}); 
			}

		}
	});

})();
