'use strict';
app.factory('customersService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var customersServiceFactory = {};

    var _getCustomers = function () {

        return $http.get(serviceBase + 'api/customer').then(function (results) {
            return results;
        });
    };

    var _getUsers = function () {

        return $http.get(serviceBase + '/api/accounts/users').then(function (results) {
            return results;
        });
    };


    var _getUsersbyId = function (id) {
      
        return $http.get(serviceBase + 'accounts/user?id=' + id).then(function (results) {
            debugger;
            return results;
        });
    };


    var _getCustomerRoles = function () {

        return $http.get(serviceBase + 'api/customerroles').then(function (results) {
            return results;
        });
    };

    var _getCustomer = function (id) {
        //alert("View");
        return $http.get(serviceBase + 'api/customer?id=' + id).then(function (results) {
            return results;
        });
    };

    var _editCustomer = function (id, customer) {
     
        return $http.put(serviceBase + 'api/customer?id=' + id, customer).then(function (results) {
            return results;
        });
    };

    var _addCustomer = function (customer) {

        return $http.post(serviceBase + 'api/customer', customer).then(function (results) {
            return results;
        });
    };

    customersServiceFactory.getCustomers = _getCustomers;
    customersServiceFactory.getCustomerRoles = _getCustomerRoles;
    customersServiceFactory.getCustomer = _getCustomer;
    customersServiceFactory.editCustomer = _editCustomer;
    customersServiceFactory.addCustomer = _addCustomer;

    customersServiceFactory.getUsers = _getUsers;
    customersServiceFactory.getUserbyId = _getUsersbyId;

    



    return customersServiceFactory;

}]);