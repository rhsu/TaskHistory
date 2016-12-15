(function () {
	const app = angular.module('app');

	console.log("task service is registered");

	app.factory('TaskService', function ($http) {
		var tasks = [];
		var returnObj = {}

		/*returnObj.initTasks = returnObj.refreshTasks().then(function () {
			return tasks;
		}, function (reason) {
			//placeholder here for error handling...
		});*/

		returnObj.getTasks = function () {
			return $http.post('/Tasks/GetTasks/');
			/*then (function (response) {
				//console.log(response);
				//tasks = response.data;
				return response.data;
			}, function (reason) {
				//placeholder here for error handling...
			});*/
		};

		/*returnObj.getTasks = function () { return tasks; };

		returnObj.initTasks = returnObj.refreshTasks();*/


		return returnObj;
		/*return {

			initTasks = refreshTasks().then(function () {
				return tasks;
			}, function (reason) {
				//placeholder here for error handling...
			}),

			refreshTasks() {
				return $http.post('/Tasks/GetTasks/')
				.then(function (response) {
					response.data = tasks;
				}, function (reason) {
					//placeholder here for error handling...
				});
			}
		}*/
	});

})();