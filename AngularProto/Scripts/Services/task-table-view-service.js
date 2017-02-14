(function() {
	const app = angular.module('app');	

	function TaskTableView(taskId, 
		taskContent) {
		this.taskId = taskId,
		this.taskContent = taskContent,

		this.editorTaskContent = taskContent

		// valid editor states are:
		// 'initial' : indicates loaded from the database
		// 'confirmDelete' : indicates that user is about to delete it
		// 'deleted' : indicates passed the confirmDelete state
		// 'editing' : indicates that the task is in inline-editing mode
		this.editorState = 'initial',

		///////////////////////////////
		//							//
		// state change functions	//
		//							//
		//////////////////////////////
		this.setInitialState = function () {
			this.editorTaskContent = taskContent;
			this.editorState = 'initial';
		},

		this.setConfirmDeleteState = function () {
			this.editorState = 'confirmDelete';
		},

		this.setDeletedState = function () {
			this.editorState = 'deleted';
		},

		this.setEditingState = function () {
			this.editorState = 'editing';
		}
	}

	//TODO: I would like to refactor this to something that indicates that it
	//      is responsible to creating a {model} while invoking the {task-service}
	//		What is an appropriate name for task-service to indicate
	//		that is talks to the server via $http (like a repo).
	//		Another thing we can do is simply differentiate these by folder structure
	app.factory('TaskTableViewService', function (TaskService) {

		return {
			retrieve() {
				return TaskService.retrieve().then(function (response) {
					jsonObject = response.data;

					const tasks = [];

					for (let jsonObject of response.data) {
						const task = new TaskTableView(jsonObject.TaskId,
							jsonObject.TaskContent);

						tasks.push(task);
					}

					return tasks;
				}, function (reason) {});
			},

			create(taskData) {
				return TaskService.create(taskData.taskContent).then(function (response) {
					jsonObject = response.data;

					return new TaskTableView(jsonObject.TaskId,
						jsonObject.TaskContent);
				}, function (reason) {});
			},

			deleteTask(task) {
				return TaskService.updateTaskIsDeleted(task.taskId, true).then(function (response) {
					if (response.data) {
						// TODO maybe the endpoint returns the entire task as is in the database
						// then the client does something like 
							// 1. makeTaskModelFromResponse
							// 2. set task = the object from step 1
						task.setDeletedState();

						return task;
					}

				}, function (reason) {
					// TODO placeholder for error handling
				});
			},

			undoDeleteTask(task) {
				return TaskService.updateTaskIsDeleted(task.taskId, false).then(function (response) {
					if (response.data) {
						// TODO maybe the endpoint returns the entire task as is in the database
						// then the client does something like 
							// 1. makeTaskModelFromResponse
							// 2. set task = the object from step 1
						task.setInitialState();

						return task;
					}
				}, function (reason) {
					// TODO placeholder for error handling
				});
			}
		}
	});
})();