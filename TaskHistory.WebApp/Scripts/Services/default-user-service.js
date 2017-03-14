(function () {
  const app = angular.module('app');

  app.factory('DefaultUserService', function ($http) {
    return {
      defaultUserExists: function () {
        return $http.post('/Authentication/DefaultUserExists');
      },

      registerDefaultUser: function () {
        return $http.post('/Authentication/RegisterDefaultUser');
      }
    }
  });
})();
