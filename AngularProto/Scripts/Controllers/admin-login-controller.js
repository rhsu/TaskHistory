(function () {
  var app = angular.module('app');

  app.controller('AdminLoginController', function ($scope,
    UserLoginService) {

    $scope.formData = {};
		$scope.formData.username = '';
		$scope.formData.password = '';

    $scope.fns = {};

    $scope.fns.login = function () {
      UserLoginService.promiseLoginAdmin($scope.formData)
        .then(function (response) {
          console.log(response);
        }, function () {});
    }

  });

})();
