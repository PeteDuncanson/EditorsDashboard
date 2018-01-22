using Our.Umbraco.EditorsDashboard.Data.Repositories;
using Our.Umbraco.EditorsDashboard.Services;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Trees;

namespace Our.Umbraco.EditorsDashboard
{
    internal class Bootstrap : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var service = new EditorsDashboardService();

            //TODO: Listen for content delete event

            // Register the Favourite Content menu item
            ContentTreeController.MenuRendering += (sender, args) =>
            {
                if (sender.TreeAlias.InvariantEquals(Constants.Trees.Content))
                {
                    var nodeId = int.Parse(args.NodeId);
                    if (nodeId > 0)
                    {
                        // Check if the user has already favourited the node
                        var hasFavourited = service.HasFavourite(nodeId, UmbracoContext.Current.Security.CurrentUser.Id);

                        // Set the menu item attributes
                        var menuTitle = !hasFavourited
                            ? "Add to Favourites"
                            : "Remove from Favourites";

                        var actionJs = !hasFavourited
                            ? "edFavouritesService.AddToFavourites"
                            : "edFavouritesService.RemoveFromFavourites";

                        // Create the menu item
                        var i = new MenuItem("addToFavourites", menuTitle)
                        {
                            Icon = "pushpin",
                            SeperatorBefore = true
                        };

                        // Set action to correct view
                        i.AdditionalData.Add("jsAction", actionJs);

                        // Insert the menu item
                        var paIdx = args.Menu.Items.FindIndex(x => x.Alias == "delete");

                        args.Menu.Items.Insert(paIdx + 1, i);
                    }
                }
            };

            // Setup DB tables
            new FavouriteContentRepository().EnsureDatabaseTable();
        }
    }
}