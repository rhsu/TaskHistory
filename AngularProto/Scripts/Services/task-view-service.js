(function() {
	const app = angular.module('app');	

	function TaskTableView(taskId, 
		taskContent, 
		isDeleted) {
		this.taskId = taskId,
		this.taskContent = taskContent,
		this.isDeleted = isDeleted,

		// editor states
		this.isEditing = false,
		this.isConfirmDelete = false,

		// accessor functions
		this.setDeleted = function (flag) {
			this.isDeleted = flag;
		},

		this.setConfirmDelete = function (flag) {
			this.isConfirmDelete = flag;
		}
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
						for (let i = 0; i < jsonObject.length; i++) {
							const task = new TaskTableView(jsonObject[i].TaskId,
								jsonObject[i].TaskContent,
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