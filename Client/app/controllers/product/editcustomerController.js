'use strict';
app.controller('editcustomerController', [
    '$scope', '$location', '$timeout', 'customersService', '$routeParams', '$filter',
    function ($scope, $location, $timeout, customersService, $routeParams, $filter) {
        $scope.savedSuccessfully = false;
        $scope.message = "";
        $scope.selectedUser = "";

        $scope.customer = [];
        $scope.users = [];
        var customerId = "";
        $scope.roles = [
            'guest',
            'user',
            'customer',
            'admin'
        ];

        $scope.userroles = [
            'guest',
            'user',
            'customer',
            'admin'
        ];
        $scope.submit = function() {
            $scope.customer.userId = $scope.selectedUser;
            customersService.editCustomer($routeParams.id, $scope.customer).then(function(response) {

                    $scope.savedSuccessfully = true;
                    $scope.message = "Customer has been successfully saved";
                    startTimer();

                },
                function(response) {
                    var errors = [];
                    for (var key in response.data.modelState) {
                        for (var i = 0; i < response.data.modelState[key].length; i++) {
                            errors.push(response.data.modelState[key][i]);
                        }
                    }
                    $scope.message = "Failed to save customer due to:" + errors.join(' ');
                });
        };

        var startTimer = function() {
            var timer = $timeout(function() {
                $timeout.cancel(timer);
                $location.path('/customers');
            }, 2000);
        }


        $scope.loadUsers = function () {
            customersService.getUsers().then(function (results) {
                $scope.users = results.data;
                $scope.loadSelectedUser();


            }, function (error) {
                alert(error.data.message);
            });
        };


        $scope.loadRoles = function () {
            customersService.getUsers().then(function (results) {
                $scope.users = results.data;
                $scope.loadSelectedUser();


            }, function (error) {
                alert(error.data.message);
            });
        };


        $scope.loadCustomer = function() {
            customersService.getCustomer($routeParams.id).then(function(results) {
                $scope.customer = results.data;
                customerId = $scope.customer.userId;


            }, function(error) {
                alert(error.data.message);
            });
        };
        $scope.loadSelectedUser = function () {

            var selectedUser 
            //$scope.users.filter($scope.users.id = $scope.customer.userId);
            = $filter('filter')($scope.users, { id: customerId});
            //customersService.getUserbyId($scope.customer.userId).then(function(results) {
            //    debugger;
            //    $scope.selectedUser = results.data;;

            //}, function(error) {
            //    alert(error.data.message);
            //});
            $scope.selectedUser = selectedUser[0].id;
        };


        $scope.loadUserRoles = function() {
            customersService.getUserRoles($routeParams.id).then(function(results) {

                $scope.userroles = results.data;

            }, function(error) {
                alert(error.data.message);
            });
        };

        ////

        $scope.orderOptions = [
            { "name": "Newest", "value": "age" },
            { "name": "Alphabetical", "value": "name" }
        ];

        $scope.orderModel = $scope.orderOptions[0];

        ////


        $scope.loadUsers();
        $scope.loadRoles();
        $scope.loadCustomer();


    }
]);


