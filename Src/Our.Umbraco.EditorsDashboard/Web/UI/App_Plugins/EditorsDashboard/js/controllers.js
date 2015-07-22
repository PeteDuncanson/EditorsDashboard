angular.module("umbraco").controller("Our.Umbraco.EditorsDashboard.DashboardController", [

	"$scope",
	"$rootScope",
	"$window",
	"dialogService",
	"notificationsService",
	"Our.Umbraco.EditorsDashboard.Resources",

	function ($scope, $rootScope, $window, dialogService, notificationsService, edResources) {

        var doGetFavourites = function() {
            edResources.getFavourites().then(function (data) {
                $scope.favourites = data;
            });
        }

	    $scope.remove = function(fav) {
	        edResources.removeFavourite(fav.id).then(function () {
	            notificationsService.success("Favourite Removed", "The favourite '" + fav.name + "' was successfully removed.");
	            doGetFavourites();
	        });
	    };

	    doGetFavourites();

	}

]);

angular.module("umbraco").controller("Our.Umbraco.EditorsDashboard.DialogController", [

	"$scope",
	"$rootScope",
	"Our.Umbraco.EditorsDashboard.Resources",

	function($scope, $rootScope, buaResources) {

		

	}

]);