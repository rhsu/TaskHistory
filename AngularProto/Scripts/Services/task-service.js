(function () {
	const app = angular.module('app');

	app.factory('TaskService', function ($http) {
		
		return {
			getTasks() {
				return $http.post('/Tasks/GetTasks/');
			},

			// TODO I don't like passing the whole object. Should just pass what is necessary at min.
			insertTask(formData) {
				return $http.post('/Tasks/CreateTask/', { content: formData.taskContent });
			},

			updateTaskIsDeleted(taskId, status) {
				return $http.post('/Tasks/SetTaskIsDeleted/', { taskId: taskId, status: status });
			}
		}
	});

})();