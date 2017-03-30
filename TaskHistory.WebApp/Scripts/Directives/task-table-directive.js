(function () {
  const app = angular.module('app');

  app.directive('taskTable', function (TaskService,
    TaskTableViewFactory) {

    return {
      restrict: 'E',
      templateUrl: 'Content/task-table-template.html',
      scope: {
        tasks: '='
      },
      link: function($scope, elem, attr, ctrl) {
        $scope.pageFns = {};

        $scope.pageFns.updateTaskContent = function (task) {
          task.taskContent = task.editorTaskContent;
          task.editorTaskContent = task.taskContent;
          TaskService.update(task).then(function (response) {
            const data = response.data;
            if (data) {
              TaskTableViewFactory.updateFromJson(data, task);
              task.setInitialState();
            }
          }, function () {});
        }

        $scope.pageFns.deleteTask = function (task) {
            task.isDeleted = true;
            TaskService.update(task).then(function (response) {
                const data = response.data;
                if (data) {
                    TaskTableViewFactory.updateFromJson(data, task);
                    task.setDeletedState();
                }
            }, function () {});
        }

        $scope.pageFns.undoDeleteTask = function (task) {
            task.isDeleted = false;
            TaskService.update(task).then(function (response) {
                const data = response.data;
                if (data) {
                    TaskTableViewFactory.updateFromJson(data, task);
                    task.setInitialState();
                }
            }, function () {});
        }

        $scope.pageFns.displayBackButton = function (task) {
            return (task.editorState === 'confirmDelete' || task.editorState === 'editing');
        }

        $scope.pageFns.displayReadonlyMode = function (task) {
            return (task.editorState !== 'deleted' && task.editorState !== 'editing');
        }
      }
    }
  });
})();
