(function() {
  const app = angular.module('app');

  app.controller('DefaultUserController', function ($scope,
    DefaultUserService) {
    $scope.pageState = {};

    $scope.pageState.defaultUserExists = false;
  });

})();
