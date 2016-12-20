(function() {
	const app = angular.module('app');	

	function TaskTableView(taskId, 
		taskContent) {
		this.taskId = taskId,
		this.taskContent = taskContent,

		// valid editor states are:
		// 'initial' : indicates loaded from the database
		// 'confirmDelete' : indicates that user about to delete it
		// 'deleted' : indicates passed the confirmDelete state
		this.editorState = 'initial',

		///////////////////////////////
		//							//
		// state change functions	//
		//							//
		//////////////////////////////
		this.setInitialState = function () {
			this.editorState = 'initial';
		},

		this.setConfirmDeleteState = function () {
			this.editorState = 'confirmDelete';
		},

		this.setDeletedState = function () {
			this.editorState = 'deleted';
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

						const tasks = [];

						for (let jsonObject of response.data) {
							const task = new TaskTableView(jsonObject.TaskId,
								jsonObject.TaskContent);

							tasks.push(task);
						}

						return tasks;
					}
				}, function (reason) {
					// TODO placeholder for error handling
				});
			}
		}
	});
})();