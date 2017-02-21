(function () {
    const app = angular.module('app');

    app.controller('TasksController', function ($scope, 
                                                TaskTableViewService,
                                                TaskTableViewFactory) {
        $scope.pageData = {};
        $scope.pageData.tasks = [];

        $scope.formData = {};
        $scope.formData.taskContent = '';

        $scope.pageFns = {};

        var refreshTasks = function () {
            TaskTableViewService.retrieve().then(function (tasks) {
              console.log(tasks);

                $scope.pageData.tasks = tasks;
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
            TaskTableViewService.create($scope.formData)
                .then(function (response) {
                    if (response) {
                        resetForm();
                        $scope.pageData.tasks.push(response);
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
