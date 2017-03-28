(function () {

  const app = angular.module('app');

  app.controller('TaskListsController', function ($scope,
    TaskListsService,
    $rootScope) {

    const listFeature = $rootScope.appData.flags.find(function(elem) {
      return elem.name == 'list';
    });

    $scope.featureEnabled = {}
    $scope.featureEnabled.list = listFeature && listFeature.value === 'enabled'

    $scope.formData = {};

    $scope.pageFns = {};

    $scope.pageFns.createTaskList = function () {
      TaskListsService.create($scope.formData.name).then(function (data) {
        console.log(data);
      }, function (reason) {});
    }

    TaskListsService.read(function (response) {
      console.log('in the read!');
      console.log(response);
    }, function () {});

  });

})();
