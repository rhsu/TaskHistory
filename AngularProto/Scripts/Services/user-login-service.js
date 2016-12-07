(function () {
	var app = angular.module('app');

	app.factory('UserLoginService', function ($http) {
		return {
			test() {
				console.log('worked');
			},

			loginUser(loginVM) {
				/*$http.post('').then(function (response) {
					
				}), function (reason) {

				});*/
			}
		}

	}); 
})();