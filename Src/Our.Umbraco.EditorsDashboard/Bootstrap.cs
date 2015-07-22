using Our.Umbraco.EditorsDashboard.Data.Repositories;
using Umbraco.Core;
using Umbraco.Web;

namespace Our.Umbraco.EditorsDashboard
{
    internal class Bootstrap : ApplicationEventHandler
    {
        protected override void ApplicationStarted( UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //TODO: Listen for content delete event

            // Register the IpFilter menu item
            global::Umbraco.Web.Trees.ContentTreeController.MenuRendering += (sender, args) =>
            {
                if (sender.TreeAlias == "content")
                { 
                    var nodeId = int.Parse(args.NodeId);
                    if (nodeId > 0)
                    {
                        //TODO: Lookup favourite for node / user
                        //TODO: If existing, remove, if new, add

                        // Create the menu item
                        var i = new global::Umbraco.Web.Models.Trees.MenuItem("addToFavourites", "Add to Favourites")
                        {
                            Icon = "pushpin",
                            SeperatorBefore = true
                        };

                        // Set action to correct view
                        i.AdditionalData.Add("jsAction", "edFavouritesService.AddToFavourites");

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
