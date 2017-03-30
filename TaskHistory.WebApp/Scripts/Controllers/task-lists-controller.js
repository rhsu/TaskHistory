(function () {

  const app = angular.module('app');

  app.controller('TaskListsController', function ($scope,
    TaskListsService,
    TaskListWithTasksFactory,
    $rootScope) {

    const listFeature = $rootScope.appData.flags.find(function(elem) {
      return elem.name == 'list';
    });

    $scope.featureEnabled = {}
    $scope.featureEnabled.list = listFeature && listFeature.value === 'enabled'

    $scope.formData = {};

    $scope.pageFns = {};

    $scope.pageFns.createTaskList = function () {
      TaskListsService.create($scope.formData.name).then(function (data) {
        console.log(data);
      }, function (reason) {});
    }

    TaskListsService.read().then(function (response) {
      const data = response.data;
      if (data) {
        const taskListsWithTasks = TaskListWithTasksFactory.buildFromJsonCollection(data);
        console.log(taskListsWithTasks);
      }
    }, function () {});

  });

})();
