(function () {
	const app = angular.module('app');

	app.factory('TaskService', function ($http) {
		
		return {
			getTasks() {
				return $http.post('/Tasks/Retrieve/');
			},

			createTask(content) {
				return $http.post('/Tasks/Create/', { content: content });
			},

            // This has been marked for deletion
			updateTaskIsDeleted(taskId, status) {
				return $http.post('/Tasks/SetTaskIsDeleted/', { taskId: taskId, status: status });
			},
            
            editTask(task) {
                return $http.post('/Tasks/Edit', { editViewModel : task});
            }
		}
	});
    
}());