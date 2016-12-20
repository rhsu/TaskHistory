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

			deleteTask(taskId) {
				return $http.post('/Tasks/DeleteTask/', { taskId: taskId });
			}
		}
	});

})();