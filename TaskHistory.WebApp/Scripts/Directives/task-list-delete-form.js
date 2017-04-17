(function () {

  const app = angular.module('app');

  app.directive('taskListDeleteForm', function () {

    return {
      restrict: 'E',
      templateUrl: 'Content/task-list-delete-form.html',
      scope: {
        list: '='
      },
      link: function ($scope, elem, attr, ctrl) {
        //some stuff happens here

        $scope.pageFns = {};

        $scope.pageFns.deleteTask = function (list, inclueTasks) {
          // some stuff happens and then...

          // TODO should be deletedState()
          list.initialState();
        }
      }
    }

  });

})();
