(function() {
  const app = angular.module('app');

  app.directive('taskListEditForm', function (TaskListsService,
    TaskListWithTasksFactory) {

    return {
      restrict: 'E',
      templateUrl: 'Content/task-list-edit-form.html',
      scope: {
        list: '='
      },

      link: function ($scope, elem, attr, ctrl) {
          $scope.directiveFns = {};

          $scope.directiveFns.editList = function (list) {

            TaskListsService.update(list.listId, { name: list.listName, isDeleted: list.isDeleted })
              .then(function (response) {
                const data = response.data;
                if (data) {
                  TaskListWithTasksFactory.updateFromJson(list, data);
                  list.initialState();
                }
              }, function () {})
          }

      }
    }

  });
})();
