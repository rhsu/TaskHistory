(function() {
	const app = angular.module('app');	

	//TODO: I would like to refactor this to something that indicates that it
	//      is responsible to creating a {model} while invoking the {task-service}
	//		What is an appropriate name for task-service to indicate
	//		that is talks to the server via $http (like a repo).
	//		Another thing we can do is simply differentiate these by folder structure
	app.factory('TaskViewService', function (TaskService) {

		return {
			getTasksForTableView() {
				getTasks().then(function (response) {
					if (response.data) {
						var retVal = [];

						// TODO what is the ECMASCRIPT 6 way of doing this
						for (var i = 0; i < response.data.length; i++) {
							
						}
					}
				}, function (reason) {
					// TODO placeholder for error handling
				});
			}
		}
	});
})();