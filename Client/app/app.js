

var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar', 'ui.bootstrap']);

app.config(function ($routeProvider) {

    $routeProvider.when("/add-product/", {
        controller: "addproductController",
        templateUrl: "/app/views/product/add.html"
    });

    $routeProvider.when("/edit-product/:id", {
        controller: "editproductController",
        templateUrl: "/app/views/product/edit.html"
    });

    $routeProvider.when("/view-product/:id", {
        controller: "viewproductController",
        templateUrl: "/app/views/product/view.html"
    });

    $routeProvider.when("/products", {
        controller: "productsController",
        templateUrl: "/app/views/product/products.html"
    });
    
    $routeProvider.when("/add-customer/", {
        controller: "addcustomerController",
        templateUrl: "/app/views/customer/add.html"
    });

    $routeProvider.when("/edit-customer/:id", {
        controller: "editcustomerController",
        templateUrl: "/app/views/customer/edit.html"
    });

    $routeProvider.when("/view-customer/:id", {
        controller: "viewcustomerController",
        templateUrl: "/app/views/customer/view.html"
    });

    $routeProvider.when("/customers", {
        controller: "customersController",
        templateUrl: "/app/views/customer/customers.html"
    });


    $routeProvider.when("/add-question/", {
        controller: "addquestionController",
        templateUrl: "/app/views/question/add.html"
    });

    $routeProvider.when("/edit-question/:id", {
        controller: "editquestionController",
        templateUrl: "/app/views/question/edit.html"
    });

    $routeProvider.when("/view-question/:id", {
        controller: "viewquestionController",
        templateUrl: "/app/views/question/view.html"
    });
    
    $routeProvider.when("/questions", {
        controller: "questionsController",
        templateUrl: "/app/views/question/questions.html"
    });

    $routeProvider.when("/categories", {
        controller: "categoriesController",
        templateUrl: "/app/views/category/categories.html"
    });

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $routeProvider.when("/passwordreset", {
        controller: "passwordresetController",
        templateUrl: "/app/views/passwordreset.html"
    });

    $routeProvider.when("/orders", {
        controller: "ordersController",
        templateUrl: "/app/views/orders.html"
    });

    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: "/app/views/refresh.html"
    });

    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: "/app/views/tokens.html"
    });

    $routeProvider.when("/associate", {
        controller: "associateController",
        templateUrl: "/app/views/associate.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });

});


var serviceBase = 'http://localhost:57310/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

app.filter('offset', function () {
    return function (input, start) {
        start = parseInt(start, 10);
        return input.slice(start);
    };
});


