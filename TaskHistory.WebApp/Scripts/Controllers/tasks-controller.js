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

    });
})();
