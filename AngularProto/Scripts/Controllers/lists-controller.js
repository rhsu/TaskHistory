(function () {
    'use strict';
    
    const app = angular.module('app');
    
    app.controller('ListsController', function ($scope,
                                                ListsTableViewService){
        
        const a = ListsTableViewService.test();
        console.log(a);
    });
})();