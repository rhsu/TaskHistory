(function () {
	const app = angular.module('app');

	app.controller('TasksController', function ($scope, TaskService) {
		$scope.pageData = {};
		$scope.pageData.tasks = [];

		$scope.formData = {};
		$scope.formData.taskContent = '';

		$scope.pageFns = {};

		var refreshTasks = function () {
			TaskService.getTasks().then(function (response) {
				$scope.pageData.tasks = response.data;
			}, function (reason) {
				// placeholder for error handling...
			});
		};

		refreshTasks();

		$scope.pageFns.insertTask = function () {
			TaskService.insertTask($scope.formData.taskContent)
				.then(function (response) {
					if (response.data) {
						$scope.formData.taskContent = '';
						refreshTasks();
					}
				}, function (reason) {

				});
		};
	});
})();