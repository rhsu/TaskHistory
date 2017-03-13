(function() {
  const app = angular.module('app');

  app.controller('DefaultUserController', function ($scope,
    DefaultUserService) {
    $scope.pageState = {};
    $scope.pageState.defaultUserExists = false;

    DefaultUserService.defaultUserExists().then(function (response) {
      console.log(response.data);

      if (response.data) {
        $scope.pageState.defaultUserExists = response.data;
      }
    }, function () {});

    $scope.pageFns = {};

    $scope.pageFns.registerDefaultUser = function () {
      DefaultUserService.registerDefaultUser().then(function (response) {
        if (response.data) {
          $scope.pageState.defaultUserExists = true;
        }
      }, function () {});
    }

  });

})();
