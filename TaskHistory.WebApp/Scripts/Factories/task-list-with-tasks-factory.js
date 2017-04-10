(function () {
  const app = angular.module('app');

  function TaskListWithTasks(listId, listName, tasks) {
    this.listId = listId;
    this.listName = listName;
    this.tasks = tasks;

    // state variables
    this.showTasks = true;
    this.showAddTaskForm = false;
    this.showConfirmDelete = false;

    this.taskFormName = '';

    /*this.initialState = function() {
      this.states = {
        showTasks: true,
        showAddTaskForm: false,
        showConfirmDelete: false
      };

      console.log(this.states);
    }*/

    this.initialState();
  }

  TaskListWithTasks.prototype.initialState = function () {
    // state variables
    this.showTasks = true;
    this.showAddTaskForm = false;
    this.showConfirmDelete = false;

    this.states = {
      showTasks: true,
      showAddTaskForm: false,
      showConfirmDelete: false
    };

    this.setState('showConfirmDelete');
  }

  TaskListWithTasks.prototype.setState = function (state) {
    for (s in this.states) {
      /*if (s === state) {
        this.states[s] = true;
      } else {
        this.states[s] = false;
      }*/
      this.states[s] = (s === state);
    }

    console.log(this.states);
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
