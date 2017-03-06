(function () {
    'use strict';
    
    const app = angular.module('app');
    
    app.controller('ListsController', function ($scope,
                                                ListsTableViewService){
        
        const a = ListsTableViewService.mock();
        console.log(a);
    });
})();