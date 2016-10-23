'use strict';
app.controller('editquestionController', ['$scope', '$location', '$timeout', 'questionsService', '$routeParams', function ($scope, $location, $timeout, questionsService, $routeParams)
{
    $scope.savedSuccessfully = false;
    $scope.message = "";
    
    $scope.question = [];
    
    $scope.submit = function () {

        questionsService.editQuestion($routeParams.id, $scope.question).then(function (response) {

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

    $scope.loadQuestion = function () {
        questionsService.getQuestion($routeParams.id).then(function (results) {

            $scope.question = results.data;

        }, function (error) {
            alert(error.data.message);
        });
    };

    $scope.loadQuestion();

}]);


