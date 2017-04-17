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

          // setting to initialState in case the user undeletes
          // TODO: review this when the promise is invoked
          //       this can be removed if we make a roundtrip
          //       retrieving the deleted TaskList
          list.initialState();
          list.isDeleted = true;
        }
      }
    }

  });

})();
