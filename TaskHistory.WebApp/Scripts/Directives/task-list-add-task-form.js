(function () {
  const app = angular.module('app');

  console.log("bundled");

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
        $scope.directiveFns = {};

        $scope.directiveFns.createTaskOnList = function ($scope.listId,
          $scope.taskContent) {

            var refreshTaskLists = function () {
              TaskListsService.read().then(function (response) {
                const data = response.data;
                if (data) {
                  const taskListsWithTasks = TaskListWithTasksFactory.buildFromJsonCollection(data);
                  $scope.pageData.taskListWithTasks = taskListsWithTasks
                }
              }, function () {});
            }

            TaskService.createTaskOnList($scope.listId, $scope.taskContent)
              .then(function (response) {

                if (response.data) {
                  refreshTaskLists();
                }

              }, function () {});

        }

        /*$scope.pageFns.createTaskOnList = function (listId, taskContent) {
          TaskService.createTaskOnList(listId, taskContent).then(function (response) {
            // TODO can this be changed to refreshTaskList (singular?)
            if (response.data) {
              refreshTaskLists();
            }
          }, function () {});
        }*/
      }
    }
  });

})();
