'use strict';
app.controller('questionsController', ['$scope', 'questionsService', function ($scope, questionsService) {

    $scope.questions = [];

    questionsService.getQuestions().then(function (results) {

        $scope.questions = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

}]);