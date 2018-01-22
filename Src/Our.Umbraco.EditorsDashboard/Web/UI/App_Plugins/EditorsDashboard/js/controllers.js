angular.module("umbraco").controller("Our.Umbraco.EditorsDashboard.DashboardController", [

    "$scope",
    "$rootScope",
    "$window",
    "dialogService",
    "notificationsService",
    "Our.Umbraco.EditorsDashboard.Resources",

    function ($scope, $rootScope, $window, dialogService, notificationsService, edResources) {

        var doGetFavourites = function () {
            edResources.getFavourites().then(function (data) {
                $scope.favourites = data;
            });
        }

        $scope.remove = function (fav) {
            console.debug("remove", fav);
            if (confirm('Are you sure?')) {
                edResources.removeFromFavourites(fav.nodeId).then(function () {
                    notificationsService.success("Favourite Removed", "'" + fav.name + "' successfully removed from your favourites.");
                    doGetFavourites();
                });
            }
        };

        doGetFavourites();

    }
]);

angular.module("umbraco").controller("Our.Umbraco.EditorsDashboard.ActionViewController", [

    "$scope",
    "$rootScope",
    "Our.Umbraco.EditorsDashboard.Resources",

    function ($scope, $rootScope, buaResources) {

        console.log($scope);

    }

]);