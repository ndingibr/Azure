'use strict';
app.factory('questionsService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var questionsServiceFactory = {};

    var _getQuestions = function () {

        return $http.get(serviceBase + 'api/question').then(function (results) {
            return results;
        });
    };

    var _getQuestion = function (id) {
        //alert("View");
        return $http.get(serviceBase + 'api/question?id=' + id).then(function (results) {
            return results;
        });
    };

    var _editQuestion = function (id, question) {
     
        return $http.put(serviceBase + 'api/question?id=' + id, question).then(function (results) {
            return results;
        });
    };

    var _addQuestion = function (question) {

        return $http.post(serviceBase + 'api/question', question).then(function (results) {
            return results;
        });
    };

    questionsServiceFactory.getQuestions = _getQuestions;
    questionsServiceFactory.getQuestion = _getQuestion;
    questionsServiceFactory.editQuestion = _editQuestion;
    questionsServiceFactory.addQuestion = _addQuestion;


    return questionsServiceFactory;

}]);