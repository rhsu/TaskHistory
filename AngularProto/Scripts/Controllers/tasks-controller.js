(function () {
	const app = angular.module('app');

	app.controller('TasksController', function ($scope, TaskViewService, TaskService) {
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

		$scope.pageFns.refreshTasks();

		$scope.pageFns.insertTask = function () {
			TaskService.insertTask($scope.formData)
				.then(function (response) {
					if (response.data) {
						resetForm();

						// TODO this should only refresh the newly created task
						refreshTasks();
					}
				}, function (reason) {
					// placeholder for error handling
				});
		};

		$scope.pageFns.deleteTask = function (id) {
			TaskService.deleteTask(id)
				.then(function (response) {
					// TODO this should only refresh the newly created task
				}, function(reason) {
					// placeholder for error handling
				});
		};
	});
})();