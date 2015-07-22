using Our.Umbraco.EditorsDashboard.Data.Repositories;
using Umbraco.Core;

namespace Our.Umbraco.EditorsDashboard
{
    internal class Bootstrap : ApplicationEventHandler
    {
        protected override void ApplicationStarted( UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //TODO: Listen for content delete event

            new FavouriteContentRepository().EnsureDatabaseTable();
        }
    }
}
