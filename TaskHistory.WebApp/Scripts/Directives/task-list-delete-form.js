(function () {

  const app = angular.module('app');

  app.directive('taskListDeleteForm', function (TaskListsService,
    TaskListWithTasksFactory) {

    return {
      restrict: 'E',
      templateUrl: 'Content/task-list-delete-form.html',
      scope: {
        list: '='
      },
      link: function ($scope, elem, attr, ctrl) {
        
        $scope.pageFns = {};

        $scope.pageFns.deleteTask = function (list, inclueTasks) {

          TaskListsService.update(list.listId, {name: list.listName, isDeleted: true})
            .then(function (response) {
              const data = response.data;
              if (data) {
                TaskListWithTasksFactory.updateFromJson(list, data);
              }
            }, {});
        }
      }
    }

  });

})();
