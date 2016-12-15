(function () {
	const app = angular.module('app');

	app.factory('TaskService', function ($http) {
		return {
			const tasks = [];

			initTasks = refreshTasks().then(function () {
				return tasks;
			}, function (reason) {
				//placeholder here for error handling...
			});

			refreshTasks() {
				return $http.post('/Tasks/GetTasks/')
				.then(function (response) {
					response.data = tasks;
				}, function (reason) {
					//placeholder here for error handling...
				});
			}
		}
	});

})();