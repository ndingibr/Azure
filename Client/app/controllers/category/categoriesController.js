'use strict';
app.controller('categoriesController', ['$scope', 'categoriesService', function($scope, categoriesService) {

    addExpandAllCollapseAll($scope);
    $scope.treeData = null;

    categoriesService.getCategories().then(function (results) {
        $scope.treeData = results.data;
    });
    $scope.action = function (node) {
        alert("Action on node : " + node.label);
    };

}]);

function addExpandAllCollapseAll($scope) {
    function rec(nodes, action) {
        for (var i = 0 ; i < nodes.length ; i++) {
            action(nodes[i]);
            if (nodes[i].children) {
                rec(nodes[i].children, action);
            }
        }
    }
    $scope.collapseAll = function () {
        rec($scope.treeData, function (node) {
            node.collapsed = true;
        });
    };
    $scope.expandAll = function () {
        rec($scope.treeData, function (node) {
            node.collapsed = false;
        });
    };
}