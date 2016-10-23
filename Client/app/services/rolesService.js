'use strict';
app.factory('rolesService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var rolesServiceFactory = {};

    var _getroles = function () {

        return $http.get(serviceBase + 'api/roles').then(function (results) {
            return results;
        });
    };
    
    rolesServiceFactory.getroles = _getroles;
    
    return rolesServiceFactory;

}]);