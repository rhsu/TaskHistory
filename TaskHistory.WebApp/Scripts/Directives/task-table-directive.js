(function () {
  const app = angular.module('app');

  app.directive('testDirective', function () {
    return {
      restrict: 'E',
      template: '<div>Hello World</div>'
    }
  });
})();
