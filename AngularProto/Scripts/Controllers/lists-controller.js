(function () {
    'use strict';
    
    const app = angular.module('app');
    
    app.controller('ListsController', function ($scope,
                                                ListsTableViewService){
        
        ListsTableViewService.test();
    });
})();