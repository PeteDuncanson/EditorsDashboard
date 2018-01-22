angular.module('umbraco.services').factory('edFavouritesService', [

    "$q",
    "navigationService",
    "notificationsService",
    "Our.Umbraco.EditorsDashboard.Resources",

    function ($q, navigationService, notificationsService, edResources) {

        return {

            AddToFavourites: function (args) {
                edResources.addToFavourites(args.entity.id).then(function () {
                    notificationsService.success("Favourite Added", "'" + args.entity.name + "' successfully added to your favourites.");
                    navigationService.hideDialog();
                });
            },

            RemoveFromFavourites: function (args) {
                edResources.removeFromFavourites(args.entity.id).then(function () {
                    notificationsService.success("Favourite Removed", "'" + args.entity.name + "' successfully removed from your favourites.");
                    navigationService.hideDialog();
                });
            }

        };
    }
]);
