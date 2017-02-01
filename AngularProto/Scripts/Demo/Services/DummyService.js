var app = angular.module('app');

app.factory('DummyService', function ($http) {

	var dummyService = {};

	dummyService.getData = function () {
		return 	$http.post('/RoutesDemo/Hello/').then(function (response) {
			console.log(response.data);
		}, function (reason) {
			console.log(reason);
		});
	};

	dummyService.postData = function () {
		return $http.post('/RoutesDemo/PostData/', { id: 5, value: "hello world" })
			.then(function (response) {
				console.log(response.data);
			}, function (reason) {
				console.log(reason);
			});
	};

	return dummyService;
});