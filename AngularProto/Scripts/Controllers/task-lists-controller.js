(function () {

  const app = angular.module('app');

  app.controller('TaskListsController', function ($scope, TaskListsService) {

    $scope.formData = {};

    $scope.pageFns = {};

    $scope.pageFns.createTaskList = function () {
      TaskListsService.create($scope.formData.name).then(function (data) {
        console.log(data);
      }, function (reason) {});
    }

  });

})();
