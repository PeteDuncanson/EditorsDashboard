angular.module('umbraco.resources').factory('Our.Umbraco.EditorsDashboard.Resources',
    function ($q, $http, umbRequestHelper) {
        return {
            getUsers: function (page) {
                var url = "/umbraco/backoffice/api/BulkUserAdminApi/GetUsers";
                return umbRequestHelper.resourcePromise(
                    $http({
                        url: url,
                        method: "GET",
                        params: {
                            p: page
                        }
                    }),
                    'Failed to get users'
                );
            }
        };
    });
