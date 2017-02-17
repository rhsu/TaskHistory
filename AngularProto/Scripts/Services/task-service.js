(function () {
	const app = angular.module('app');

	app.factory('TaskService', function ($http) {
		
		return {
            
			create(content) {
				return $http.post('/Tasks/Create/', { content: content });
			},
            
			retrieve() {
				return $http.post('/Tasks/Retrieve/');
			},
            
            update(task) {
                return $http.post('/Tasks/Edit', { viewModel : task, 
                                                   taskId : task.taskId
                                                 });
            }
		}
	});
    
}());