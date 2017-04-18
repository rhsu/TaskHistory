(function () {
  const app = angular.module('app');

  function TaskListWithTasks(listId, listName, isDeleted, tasks) {
    this.listId = listId;
    this.listName = listName;
    this.tasks = tasks;
    this.isDeleted = isDeleted;

    this.taskFormName = '';

    this.initialState();
  }

  TaskListWithTasks.prototype.initialState = function () {
    this.states = {
      showTasks: true,
      showAddTaskForm: false,
      showDeleteForm: false
    };
  }

  TaskListWithTasks.prototype.setState = function (state) {
    for (s in this.states) {
      this.states[s] = (s === state);
    }
  }

  app.factory('TaskListWithTasksFactory', function (TaskTableViewFactory) {
    return {

      buildFromJson(json) {
        const listId = json.ListId || -1;
        const listName = json.ListName || '';
        const isDeleted = json.IsDeleted;

        const tasks = TaskTableViewFactory.buildFromJsonCollection(json.Tasks);

        return new TaskListWithTasks(listId, listName, isDeleted, tasks);
      },

      buildFromJsonCollection(jsonCollection) {
        const retVal = [];

        for (let i = 0; i< jsonCollection.length; i++) {
          const current = jsonCollection[i];
          retVal.push(this.buildFromJson(current));
        }

        return retVal;
      },

      updateFromJson(list, json) {
        const listName = json.ListName || '';
        const isDeleted = json.IsDeleted;
        const tasks = json.Tasks;

        list.listName = listName;
        list.isDeleted = isDeleted;

        list.tasks = TaskTableViewFactory.buildFromJsonCollection(tasks);
      }

    }
  });
})();
