"use strict";app.factory("rolesService",["$http","ngAuthSettings",function(t,e){var r=e.apiServiceBaseUri,n={},i=function(){return t.get(r+"api/roles").then(function(t){return t})};return n.getroles=i,n}]);