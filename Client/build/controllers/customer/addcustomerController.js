"use strict";app.controller("addcustomerController",["$scope","$location","$timeout","customersService","rolesService",function(e,t,s,o,a){e.savedSuccessfully=!1,e.message="",e.roles,e.submit=function(){o.addCustomer(e.customer).then(function(t){e.savedSuccessfully=!0,e.message="Customer has been successfully saved",startTimer()},function(t){var s=[];for(var o in t.data.modelState)for(var a=0;a<t.data.modelState[o].length;a++)s.push(t.data.modelState[o][a]);e.message="Failed to save customer due to:"+s.join(" ")})},e.loadRoles=function(){a.getroles.then(function(t){e.roles=t.data},function(e){alert(e.data.message)})}}]);