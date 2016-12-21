(function () {
	const app = angular.module('app');

	app.controller('TasksController', function ($scope, TaskViewService) {
		$scope.pageData = {};
		$scope.pageData.tasks = [];

		$scope.formData = {};
		$scope.formData.taskContent = '';

		$scope.pageFns = {};

		var refreshTasks = function () {
			TaskViewService.getTasksForTableView().then(function (tasks) {
				$scope.pageData.tasks = tasks;
			}, function (reason) {
				// placeholder for error handling...
			});
		};

		var resetForm = function () {
			$scope.formData.taskContent = '';
		};

		refreshTasks();

		$scope.pageFns.refreshTasks = function () {
			refreshTasks();
		};

		$scope.pageFns.insertTask = function () {
			TaskViewService.insertTaskForTableView($scope.formData)
				.then(function (response) {
					if (response) {
						resetForm();
						$scope.pageData.tasks.push(response);
					}
				}, function (reason) {
					// placeholder for error handling
				});
		};

		$scope.pageFns.deleteTask = function (task) {
			TaskViewService.deleteTaskForTableView(task)
				.then(function (response) {
					// TODO this should only refresh the newly created task
				}, function(reason) {
					// placeholder for error handling
				});
		};

		$scope.pageFns.undoDeleteTask = function (task) {
			TaskViewService.undeleteTaskForTableView(task);
		};

		$scope.pageFns.displayBackButton = function (task) {
			return (task.editorState === 'confirmDelete' || task.editorState === 'editing');
		};

		$scope.pageFns.displayReadonlyMode = function (task) {
			return (task.editorState !== 'deleted' && task.editorState !== 'editing');
		};
	});
})();