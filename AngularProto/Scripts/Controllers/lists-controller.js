(function () {
    'use strict';

    const app = angular.module('app');

    app.controller('ListsController', function ($scope,
                                                FakeListsTableViewService){

        const a = FakeListsTableViewService.mock();
        console.log(a);
    });
})();
