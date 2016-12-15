(function () {
	const app = angular.module('app');

	app.controller('TasksController', function ($scope, TaskService) {
		$scope.pageData = {};
		$scope.pageData.tasks = [];
		$scope.pageFns = {};

		TaskService.getTasks().then(function (response) {
			$scope.pageData.tasks = response.data;
		}, function (reason) {
			// placeholder for error handling...
		});
	});
})();