(function () {
  var app = angular.module('app');

  console.log('bundled!');

  function TaskListWithTasks(listId, listName, tasks) {
    this.listId = listId;
    this.listName = listName;
    this.tasks = tasks;
  }

  app.factory('TaskListWithTasksFactory', function (TaskTableViewFactory) {
    return {

      buildFromJson(json) {
        const listId = json.ListId || -1;
        const listName = json.ListName || '';
        const tasks = TaskTableViewFactory.buildFromJsonCollection(json.Tasks);

        return new TaskListWithTasks(listId, listName, tasks);
      },

      buildFromJsonCollection(jsonCollection) {
        const retVal = [];

        for (let i = 0; i< jsonCollection.length; i++) {
          const current = jsonCollection[i];
          retVal.push(this.buildFromJson(current));
        }

        return retVal;
      }

    }
  });
})();
