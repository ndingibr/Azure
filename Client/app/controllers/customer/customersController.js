'use strict';
app.controller('customersController', ['$scope', 'customersService', function ($scope, customersService) {

    $scope.customers = [];

    customersService.getCustomers().then(function (results) {
        debugger;
        $scope.customers = results.data;

    }, function (error) {
        alert(error.data.message);
    });

}]);