(function() {
  const app = angular.module('app');

  app.controller('DefaultUserController', function ($scope) {
    $scope.pageState = {};

    $scope.pageState.defaultUserExists = false;
  });

})();
