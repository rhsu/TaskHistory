(function () {
  const app = angular.module('app');

  app.factory('TaskListsService', function ($http) {

    return {

      create(name) {
        return $http.post('/TaskLists/Create', { name: name });
      }

    }
  })

})();
