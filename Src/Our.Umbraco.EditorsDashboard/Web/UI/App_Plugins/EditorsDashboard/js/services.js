angular.module('umbraco.services').factory('edFavouritesService', [

    "$q",
    "notificationsService",
    "Our.Umbraco.EditorsDashboard.Resources",

    function ($q, notificationsService, edResources) {

        return {

            AddToFavourites: function (args) {

                edResources.addToFavourites(args.entity.id).then(function() {
                    notificationsService.success("Favourite Added", "'" + args.entity.name + "' successfully added to favourites.");
                    //TODO: Close the contect menu
                });

            }

        };

    }

]);
