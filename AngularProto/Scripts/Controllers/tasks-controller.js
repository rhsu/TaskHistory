(function () {
    const app = angular.module('app');

    app.controller('TasksController', function ($scope, 
                                                TaskService,
                                                TaskTableViewService,
                                                TaskTableViewFactory) {
        $scope.pageData = {};
        $scope.pageData.tasks = [];

        $scope.formData = {};
        $scope.formData.taskContent = '';

        $scope.pageFns = {};

        var refreshTasks = function () {
            TaskService.retrieve().then(function (response) {
                const data = response.data;
                if (data) {
                    for (let i = 0; i < data.length; i++) {
                        const task = TaskTableViewFactory.buildFromJson(data[i]);
                        $scope.pageData.tasks.push(task);
                    }
                }
            }, function (reason) {});
        };

        var resetForm = function () {
            $scope.formData.taskContent = '';
        };

        refreshTasks();

        $scope.pageFns.refreshTasks = function () {
            refreshTasks();
        };

        $scope.pageFns.insertTask = function () {
            TaskService.create($scope.formData.taskContent).then(function (response) {
                const data = response.data;
                if (data) {
                    resetForm();
                    const task = TaskTableViewFactory.buildFromJson(data);
                    $scope.pageData.tasks.push(task);
                }
            }, function (reason) {});
        };

        $scope.pageFns.deleteTask = function (task) {
            task.isDeleted = true;
            TaskTableViewService.delete(task);
        };

        $scope.pageFns.undoDeleteTask = function (task) {
            task.isDeleted = false;
            TaskTableViewService.undoDelete(task);
        };

        $scope.pageFns.displayBackButton = function (task) {
            return (task.editorState === 'confirmDelete' || task.editorState === 'editing');
        };

        $scope.pageFns.displayReadonlyMode = function (task) {
            return (task.editorState !== 'deleted' && task.editorState !== 'editing');
        };
    });
})();
