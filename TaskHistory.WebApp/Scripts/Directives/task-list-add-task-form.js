(function () {
  const app = angular.module('app');

  app.directive('taskListAddTaskForm', function (TaskService,
    TaskTableViewFactory,
    TaskListsService,
    TaskListWithTasksFactory) {

    return {
      restrict: 'E',
      templateUrl: 'Content/task-list-add-task-form.html',
      scope: {
        list: '='
      },
      link: function ($scope, elem, attr, ctrl) {

        /*var refreshTaskList = function () {
          TaskListsService.read($scope.list.listId).then(function (response) {
            const data = response.data;
            if (data) {
              const taskListsWithTasks = TaskListWithTasksFactory.buildFromJson(data);
              console.log(taskListWithTask);
              $scope.list = taskListsWithTasks;
            }
          }, function () {});
        }*/

        $scope.directiveFns = {};
        $scope.directiveFns.createTaskOnList = function () {

          TaskService.createTaskOnList($scope.list.listId,
            $scope.list.taskFormName).then(function (response) {

              // TODO instead of doing this, can I just set the value
              // equal to the return value from the response?
              const data = response.data;
              if (data) {
                //refreshTaskList();

                // TODO explore this
                // $scope.list = TaskListWithTasksFactory.buildFromJson(response.data);
                const newTask = TaskTableViewFactory.buildFromJson(data);
                $scope.list.tasks.push(newTask);
              }

          }, function () {});

        }
      }
    }
  });

})();
