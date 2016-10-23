'use strict';
app.controller('addproductController', [
    '$scope', '$location', '$timeout', 'productsService', 'categoriesService',
    function ($scope, $location, $timeout, productsService, categoriesService) {

        $scope.savedSuccessfully = false;
        $scope.message = "";

        $scope.product = {
            name: "",
            description: "",
            price: "",
            productCost: "",
            active: "",
            categoryId: ""
        };

        $scope.categories = [];

        categoriesService.getCategories().then(function (results) {
            $scope.categories = results.data;
        });



        $scope.add = function () {

            if ($scope.product.$valid) {
                alert('our form is amazing');
            }

            productsService.addproduct($scope.product).then(function(response) {

                    $scope.savedSuccessfully = true;
                    $scope.message = "product has been successfully saved";
                    startTimer();

                },
                function(response) {
                    var errors = [];
                    for (var key in response.data.modelState) {
                        for (var i = 0; i < response.data.modelState[key].length; i++) {
                            errors.push(response.data.modelState[key][i]);
                        }
                    }
                    $scope.message = "Failed to save product due to:" + errors.join(' ');
                });
        };

        var startTimer = function() {
            var timer = $timeout(function() {
                $timeout.cancel(timer);
                $location.path('/products');
            }, 2000);
        }
 
    }
]);


