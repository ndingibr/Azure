var app=angular.module("AngularAuthApp",["ngRoute","LocalStorageModule","angular-loading-bar","ui.bootstrap"]);app.config(function(e){e.when("/add-product/",{controller:"addproductController",templateUrl:"/app/views/product/add.html"}),e.when("/edit-product/:id",{controller:"editproductController",templateUrl:"/app/views/product/edit.html"}),e.when("/view-product/:id",{controller:"viewproductController",templateUrl:"/app/views/product/view.html"}),e.when("/products",{controller:"productsController",templateUrl:"/app/views/product/products.html"}),e.when("/add-customer/",{controller:"addcustomerController",templateUrl:"/app/views/customer/add.html"}),e.when("/edit-customer/:id",{controller:"editcustomerController",templateUrl:"/app/views/customer/edit.html"}),e.when("/view-customer/:id",{controller:"viewcustomerController",templateUrl:"/app/views/customer/view.html"}),e.when("/customers",{controller:"customersController",templateUrl:"/app/views/customer/customers.html"}),e.when("/add-question/",{controller:"addquestionController",templateUrl:"/app/views/question/add.html"}),e.when("/edit-question/:id",{controller:"editquestionController",templateUrl:"/app/views/question/edit.html"}),e.when("/view-question/:id",{controller:"viewquestionController",templateUrl:"/app/views/question/view.html"}),e.when("/questions",{controller:"questionsController",templateUrl:"/app/views/question/questions.html"}),e.when("/categories",{controller:"categoriesController",templateUrl:"/app/views/category/categories.html"}),e.when("/home",{controller:"homeController",templateUrl:"/app/views/home.html"}),e.when("/login",{controller:"loginController",templateUrl:"/app/views/login.html"}),e.when("/signup",{controller:"signupController",templateUrl:"/app/views/signup.html"}),e.when("/passwordreset",{controller:"passwordresetController",templateUrl:"/app/views/passwordreset.html"}),e.when("/orders",{controller:"ordersController",templateUrl:"/app/views/orders.html"}),e.when("/refresh",{controller:"refreshController",templateUrl:"/app/views/refresh.html"}),e.when("/tokens",{controller:"tokensManagerController",templateUrl:"/app/views/tokens.html"}),e.when("/associate",{controller:"associateController",templateUrl:"/app/views/associate.html"}),e.otherwise({redirectTo:"/home"})});var serviceBase="http://localhost:57310/";app.constant("ngAuthSettings",{apiServiceBaseUri:serviceBase,clientId:"ngAuthApp"}),app.config(function(e){e.interceptors.push("authInterceptorService")}),app.run(["authService",function(e){e.fillAuthData()}]),app.filter("offset",function(){return function(e,t){return t=parseInt(t,10),e.slice(t)}});