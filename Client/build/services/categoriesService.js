"use strict";app.factory("categoriesService",["$http","ngAuthSettings",function(t,e){var r=e.apiServiceBaseUri,i={},n=function(){return t.get(r+"api/category").then(function(t){return t})};return i.getCategories=n,i}]);