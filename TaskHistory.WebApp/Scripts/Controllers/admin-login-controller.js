(function () {
  var app = angular.module('app');

  app.controller('AdminLoginController', function ($scope,
    $location,
    UserLoginService) {

    $scope.formData = {};
		$scope.formData.username = '';
		$scope.formData.password = '';

    $scope.fns = {};

    $scope.fns.login = function () {
      UserLoginService.promiseLoginAdmin($scope.formData)
        .then(function (successful) {
          if (successful) {
            $location.path('Admin/FeatureFlags')
          }
        }, function () {});
    }

  });

})();
