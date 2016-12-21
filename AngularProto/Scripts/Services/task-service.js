(function () {
	const app = angular.module('app');

	app.factory('TaskService', function ($http) {
		
		return {
			getTasks() {
				return $http.post('/Tasks/GetTasks/');
			},

			// TODO I don't like passing the whole object. Should just pass what is necessary at min.
			insertTask(content) {
				return $http.post('/Tasks/CreateTask/', { content: content });
			},

			updateTaskIsDeleted(taskId, status) {
				return $http.post('/Tasks/SetTaskIsDeleted/', { taskId: taskId, status: status });
			}
		}
	});

})();