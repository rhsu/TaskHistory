(function () {
  const app = angular.module('app');

  app.directive('taskListAddTaskForm', function (TaskService,
    TaskListsService,
    TaskListWithTasksFactory) {

    return {
      restrict: 'E',
      templateUrl: 'Content/task-list-add-task-form.html',
      scope: {
        taskContent: '=',
        listId: '=',
        listName: '='
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
        $scope.directiveFns.createTaskOnList = function ($scope.listId,
          $scope.taskContent) {

            TaskService.createTaskOnList($scope.listId, $scope.taskContent)
              .then(function (response) {

                if (response.data) {
                  refreshTaskLists();
                }

              }, function () {});

        }
      }
    }
  });

})();
