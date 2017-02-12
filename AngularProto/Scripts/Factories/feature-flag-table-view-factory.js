(function () {
    const app = angular.module('app');
    
    function FeatureFlagTableView(id, name, value) {
        this.id = id;
        this.name = name;
        this.value = value;
    }
    
    app.factory('FeatureFlagTableViewFactory', function () {
        return {
            
            buildFromJson(jsonObj) {
                let id = jsonObj.Id || -1;
                let name = jsonObj.Name || '';
                let value = jsonObj.Value || '';
                
                return new FeatureFlagTableView(id, name, value);
            }
            
        }
    });
    
}());