angular.module('umbraco.resources').factory('Our.Umbraco.EditorsDashboard.Resources',
    function ($q, $http, umbRequestHelper) {
        return {
            getFavourites: function (page) {
                var url = "/umbraco/backoffice/EditorsDashboard/EditorsDashboardApi/GetFavourites";
                return umbRequestHelper.resourcePromise(
                    $http({
                        url: url,
                        method: "GET"
                    }),
                    'Failed to get favourites'
                );
            },
            addToFavourites: function(nodeId) {
                var url = "/umbraco/backoffice/EditorsDashboard/EditorsDashboardApi/AddToFavourites";
                return umbRequestHelper.resourcePromise(
                    $http({
                        url: url,
                        method: "GET",
                        params: {
                            nodeId: nodeId
                        }
                    }),
                    'Failed to add to favourites'
                );
            },
            removeFromFavourites: function (nodeId) {
                var url = "/umbraco/backoffice/EditorsDashboard/EditorsDashboardApi/RemoveFromFavourites";
                return umbRequestHelper.resourcePromise(
                    $http({
                        url: url,
                        method: "POST",
                        params: {
                            nodeId: nodeId
                        }
                    }),
                    'Failed to remove from favourites'
                );
            }
        };
    });
