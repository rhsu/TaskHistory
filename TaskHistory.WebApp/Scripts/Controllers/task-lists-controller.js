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

    var refreshTaskLists = function () {
      TaskListsService.read().then(function (response) {
        const data = response.data;
        if (data) {
          const taskListsWithTasks = TaskListWithTasksFactory.buildFromJsonCollection(data);
          $scope.pageData.taskListWithTasks = taskListsWithTasks
        }
      }, function () {});
    }

    $scope.pageFns.createTaskList = function () {
      TaskListsService.create($scope.formData.name).then(function (response) {
        if (response.data) {
          refreshTaskLists();
          $scope.formData.name = '';
        }
      }, function (reason) {});
    }

    $scope.pageData = {};
    $scope.pageData.taskListWithTasks = [];

    /*TaskListsService.read().then(function (response) {
      const data = response.data;
      if (data) {
        const taskListsWithTasks = TaskListWithTasksFactory.buildFromJsonCollection(data);
        $scope.pageData.taskListWithTasks = taskListsWithTasks
      }
    }, function () {});*/

    refreshTaskLists();
  });

})();
