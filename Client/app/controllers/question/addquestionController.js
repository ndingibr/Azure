'use strict';
app.controller('addquestionController', ['$scope', '$location', '$timeout', 'questionsService', function ($scope, $location, $timeout, questionsService) {
    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.question = [];
 

    $scope.submit = function () {

        questionsService.addQuestion($scope.question).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Question has been successfully saved";
            startTimer();

        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to save question due to:" + errors.join(' ');
         });
    };

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/questions');
        }, 2000);
    }



}]);


