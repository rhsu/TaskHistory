(function () {
    'use strict';
    
    const app = angular.module('app');
    
    function FakeList(id, name, tasks) {
        this.id = id || -1;
        // TODO make this a constant
        this.name = name || 'ERROR';
        this.tasks = tasks || [];
    }
    
    FakeList.prototype.init = function () {
        const tasks = [];
                
        for (let i = 0; i < 5; i++) {
            const t = new FakeTask(i, `Task ${i}`);
            tasks.push(t);
        }
        
        this.tasks = tasks;
    }
    
    function FakeTask(id, name) {
        this.id = id || -1;
        this.name = name || 'ERROR';
    }
    
    app.factory('ListsTableViewService', function (){
        return {
            
            mock() {
                const retVal = [];
                
                for (let i = 1; i <= 5; i++) {
                    const list = new FakeList(i, `List ${i}`);
                    list.init();
                    retVal.push(list);
                }
                
                return retVal;
            }
            
        } 
    });
})();