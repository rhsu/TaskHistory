(function () {
  const app = angular.module('app');

  app.directive('taskListAddTaskForm', function (TaskService,
    TaskListsService,
    TaskListWithTasksFactory) {

    return {
      restrict: 'E',
      templateUrl: 'Content/task-list-add-task-form.html',
      scope: {
        list: '='
      },
      link: function ($scope, elem, attr, ctrl) {

        var refreshTaskLists = function () {
          TaskListsService.read().then(function (response) {
            const data = response.data;
            if (data) {
              const taskListsWithTasks = TaskListWithTasksFactory.buildFromJsonCollection(data);
              $scope.pageData.taskListWithTasks = taskListsWithTasks
            }
          }, function () {});
        }

        $scope.directiveFns = {};
        $scope.directiveFns.createTaskOnList = function () {

          TaskService.createTaskOnList($scope.list.listId,
            $scope.list.taskFormName).then(function (response) {

              if (response.data) {
                refreshTaskLists();
              }

          }, function () {});

        }
      }
    }
  });

})();
