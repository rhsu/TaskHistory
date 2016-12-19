(function() {
	const app = angular.module('app');	

	function TaskTableView(taskId, 
		taskContent, 
		isDeleted, 
		isEditing) {
		this.taskId = taskId,
		this.taskContent = taskContent,
		this.isDeleted = isDeleted,
		this.isEditing = isEditing
	}

	function Test(foo, bar) {
		this.foo;
		this.bar;
	}

	//TODO: I would like to refactor this to something that indicates that it
	//      is responsible to creating a {model} while invoking the {task-service}
	//		What is an appropriate name for task-service to indicate
	//		that is talks to the server via $http (like a repo).
	//		Another thing we can do is simply differentiate these by folder structure
	app.factory('TaskViewService', function (TaskService) {

		return {
			getTasksForTableView() {
				return TaskService.getTasks().then(function (response) {
					if (response.data) {
						jsonObject = response.data;

						const retVal = [];

						// TODO what is the ECMASCRIPT 6 way of doing this
						for (let i = 0; i < response.data.length; i++) {
							//retVal.push(new Test("foo", "bar"));
							var task = new TaskTableView(jsonObject.TaskId,
								jsonObject.TaskContent,
								false, //this is correct. should be false, 
								// but let's see if we can enforce this from the service
								false);

							retVal.push(task);
						}

						return retVal;
					}
				}, function (reason) {
					// TODO placeholder for error handling
				});
			}
		}
	});
})();