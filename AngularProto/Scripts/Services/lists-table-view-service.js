(function () {
    'use strict';
    
    const app = angular.module('app');
    
    app.factory('ListsTableViewService', function (){
        return {
            
            test() {
                console.log('works');
            }
            
        } 
    });
})();