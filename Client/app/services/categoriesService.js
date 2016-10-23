'use strict';
app.factory('categoriesService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var categoriesServiceFactory = {};

    var _getCategories = function () {

        return $http.get(serviceBase + 'api/category').then(function (results) {
            return results;
        });
    };

    //var _getUsers = function () {

    //    return $http.get(serviceBase + '/api/accounts/users').then(function (results) {
    //        return results;
    //    });
    //};


    //var _getUsersbyId = function (id) {
      
    //    return $http.get(serviceBase + 'accounts/user?id=' + id).then(function (results) {
    //        debugger;
    //        return results;
    //    });
    //};


    //var _getCategoryRoles = function () {

    //    return $http.get(serviceBase + 'api/Categoryroles').then(function (results) {
    //        return results;
    //    });
    //};

    //var _getCategory = function (id) {
    //    //alert("View");
    //    return $http.get(serviceBase + 'api/Category?id=' + id).then(function (results) {
    //        return results;
    //    });
    //};

    //var _editCategory = function (id, Category) {
     
    //    return $http.put(serviceBase + 'api/Category?id=' + id, Category).then(function (results) {
    //        return results;
    //    });
    //};

    //var _addCategory = function (Category) {

    //    return $http.post(serviceBase + 'api/Category', Category).then(function (results) {
    //        return results;
    //    });
    //};

    categoriesServiceFactory.getCategories = _getCategories;
    //categoriesServiceFactory.getCategoryRoles = _getCategoryRoles;
    //categoriesServiceFactory.getCategory = _getCategory;
    //categoriesServiceFactory.editCategory = _editCategory;
    //categoriesServiceFactory.addCategory = _addCategory;

    //categoriesServiceFactory.getUsers = _getUsers;
    //categoriesServiceFactory.getUserbyId = _getUsersbyId;

    



    return categoriesServiceFactory;

}]);