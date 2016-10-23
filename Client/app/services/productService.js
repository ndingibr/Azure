'use strict';
app.factory('productsService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var productsServiceFactory = {};

    var _getProducts = function () {

        return $http.get(serviceBase + 'api/product').then(function (results) {
            return results;
        });
    };
    



    var _getProductRoles = function () {

        return $http.get(serviceBase + 'api/productroles').then(function (results) {
            return results;
        });
    };

    var _getProduct = function (id) {
        //alert("View");
        return $http.get(serviceBase + 'api/product?id=' + id).then(function (results) {
            return results;
        });
    };

    var _editProduct = function (id, product) {
     
        return $http.put(serviceBase + 'api/product?id=' + id, product).then(function (results) {
            return results;
        });
    };

    var _addProduct = function (product) {

        return $http.post(serviceBase + 'api/product', product).then(function (results) {
            return results;
        });
    };

    productsServiceFactory.getProducts = _getProducts;
    productsServiceFactory.getProductRoles = _getProductRoles;
    productsServiceFactory.getProduct = _getProduct;
    productsServiceFactory.editProduct = _editProduct;
    productsServiceFactory.addProduct = _addProduct;

    


    return productsServiceFactory;

}]);