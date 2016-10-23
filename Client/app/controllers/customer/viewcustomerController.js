'use strict';
app.controller('viewquestionController', ['$scope', 'questionsService', '$routeParams', function ($scope, questionsService, $routeParams) {


    $scope.question = [];

    questionsService.getQuestion($routeParams.id).then(function (results) {

        $scope.question = results.data;

    }, function (error) {
        alert(error.data.message);
    });

}]);

