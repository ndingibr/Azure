'use strict';
app.controller('signupController', ['$scope', '$location', '$timeout', 'authService', function ($scope, $location, $timeout, authService) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.registration = {
        email: "",
        firstName: "",
        password: "",
        confirmPassword: "",
       dateOfBirth:""
    };
    
    $scope.signUp = function () {

        if ($scope.registration.$valid) {
            alert('our form is amazing');
        }
        
        authService.saveRegistration($scope.registration).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "User has been registered successfully, please check your email to confirm your email address";
            startTimer();

        },
         function (error) {
             var errors = [];
             for (var key in error.data.ModelState) {
                 for (var i = 0; i < error.data.ModelState[key].length; i++) {
                     errors.push(error.data.ModelState[key][i]);
                 }
             }
             $scope.message = "Failed to register user due to:" + errors.join(' ');
         });
    };

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/login');
        }, 2000);
    }

}]);
