'use strict';
app.controller('productsController', ['$scope', 'productsService', function ($scope, productsService) {

    $scope.products = [];

    productsService.getProducts().then(function (results) {
        debugger;
        $scope.products = results.data;

    }, function (error) {
        alert(error.data.message);
    });

}]);