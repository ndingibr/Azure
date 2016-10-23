'use strict';
app.controller('addcustomerController', [
    '$scope', '$location', '$timeout', 'customersService', 'rolesService',
    function ($scope, $location, $timeout, customersService,rolesService) {
        $scope.savedSuccessfully = false;
        $scope.message = "";
        $scope.roles;


        $scope.submit = function() {
            customersService.addCustomer($scope.customer).then(function(response) {

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

        $scope.loadRoles = function () {
            rolesService.getroles.then(function (results) {
                $scope.roles = results.data;
              
            }, function (error) {
                alert(error.data.message);
            });
        };
    


    }
]);


