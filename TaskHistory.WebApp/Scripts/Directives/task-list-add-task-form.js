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
          TaskListsService.readAll().then(function (response) {
            const data = response.data;
            if (data) {
              // TODO this should eventually be refresh task list (singular)
              // TODO actually can't continue until we can refresh just one task list
              const taskListsWithTasks = TaskListWithTasksFactory.buildFromJsonCollection(data);
              $scope.list = taskListsWithTasks[0];
              console.log($scope.list);
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
