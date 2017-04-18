(function () {
  const app = angular.module('app');

  app.factory('TaskListsService', function ($http) {

    return {

      create(name) {
        return $http.post('/TaskLists/Create', { name: name });
      },

      readAll() {
        return $http.post('/TaskLists/ReadAll');
      },

      read(listId) {
        return $http.post('/TaskLists/Read', { listId: listId });
      },

      update(listId, editViewModel) {
        return $http.post('/TaskLists/Update',
          { listId: listId,
            editViewModel: editViewModel});
      }

    }
  })

})();
