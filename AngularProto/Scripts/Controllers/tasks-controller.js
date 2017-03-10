(function () {
    const app = angular.module('app');

    app.controller('TasksController', function ($scope,
                                                TaskService,
                                                TaskTableViewFactory) {
        $scope.pageData = {};
        $scope.pageData.tasks = [];

        $scope.formData = {};
        $scope.formData.taskContent = '';

        $scope.pageFns = {};

        var refreshTasks = function () {
          TaskService.retrieve().then(function (response) {
            const data = response.data;
            $scope.pageData.tasks = TaskTableViewFactory.buildFromJsonCollection(data);
          }, function (reason) {});
        }

        var resetForm = function () {
            $scope.formData.taskContent = '';
        }

        $scope.pageFns.refreshTasks = function () {
          refreshTasks();
        }

        refreshTasks();

        $scope.pageFns.insertTask = function () {
            TaskService.create($scope.formData.taskContent).then(function (response) {
                const data = response.data;
                if (data) {
                    resetForm();
                    const task = TaskTableViewFactory.buildFromJson(data);
                    $scope.pageData.tasks.push(task);
                }
            }, function () {});
        };

        $scope.pageFns.updateTaskContent = function (task) {
          console.log(task);
          // TODO Why do I have editor taskContent?
          task.taskContent = task.editorTaskContent;
          task.editorTaskContent = task.taskContent;
          TaskService.update(task).then(function (response) {
            const data = response.data;
            if (data) {
              TaskTableViewFactory.updateFromJson(data, task);
              task.setInitialState();
            }
          }, function () {});
        }

        $scope.pageFns.deleteTask = function (task) {
            task.isDeleted = true;
            TaskService.update(task).then(function (response) {
                const data = response.data;
                if (data) {
                    TaskTableViewFactory.updateFromJson(data, task);
                    task.setDeletedState();
                }
            }, function () {});
        };

        $scope.pageFns.undoDeleteTask = function (task) {
            task.isDeleted = false;
            TaskService.update(task).then(function (response) {
                const data = response.data;
                if (data) {
                    TaskTableViewFactory.updateFromJson(data, task);
                    task.setInitialState();
                }
            }, function () {});
        };

        $scope.pageFns.displayBackButton = function (task) {
            return (task.editorState === 'confirmDelete' || task.editorState === 'editing');
        };

        $scope.pageFns.displayReadonlyMode = function (task) {
            return (task.editorState !== 'deleted' && task.editorState !== 'editing');
        };
    });
})();
