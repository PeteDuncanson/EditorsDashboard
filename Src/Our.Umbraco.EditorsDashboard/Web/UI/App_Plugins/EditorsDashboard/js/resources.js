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
            removeFavourite: function (favId) {
                var url = "/umbraco/backoffice/EditorsDashboard/EditorsDashboardApi/RemoveFavourite";
                return umbRequestHelper.resourcePromise(
                    $http({
                        url: url,
                        method: "POST",
                        params: {
                            id: favId
                        }
                    }),
                    'Failed to remove favourites'
                );
            }
        };
    });
