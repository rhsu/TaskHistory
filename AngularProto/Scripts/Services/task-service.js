(function () {
	const app = angular.module('app');

	app.factory('TaskService', function ($http) {
		
		return {
			getTasks() {
				return $http.post('/Tasks/GetTasks/');
			}
		}
	});

})();