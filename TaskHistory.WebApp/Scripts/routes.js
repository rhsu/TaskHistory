(function () {
  const app = angular.module('app');

  app.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/', {
      templateUrl: '/Home/Login'
    }).when('/Register', {
      templateUrl: '/Home/Register'
    }).when('/Home', {
      templateUrl: '/Tasks/Index'
    }).when('/Tasks', {
      templateUrl: '/Tasks/Index'
    }).when('/TaskLists', {
      templateUrl: '/TaskLists/Index'
    }).when('/Admin', {
      templateUrl: '/Admin/Index'
    }).when('/Admin/FeatureFlags', {
      templateUrl: '/FeatureFlags/Index'
    }).when('/History', {
      templateUrl: '/History/Index'
    }).when('/Terminal', {
      templateUrl: '/Terminal/Index'
    });

    $locationProvider.hashPrefix('');
  })
})();
