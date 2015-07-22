using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Our.Umbraco.EditorsDashboard.Services;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;

namespace Our.Umbraco.EditorsDashboard.Web.Controllers
{
    [PluginController("EditorsDashboard")]
    public class EditorsDashboardApiController : UmbracoAuthorizedApiController
    {
        private EditorsDashboardService _edService;

        public EditorsDashboardApiController()
        {
            _edService = new EditorsDashboardService();
        }

        [HttpGet]
        public void AddToFavourites(int nodeId)
        {
            _edService.AddToFavourites(nodeId, Security.CurrentUser.Id);
        }

        [HttpGet]
        public IEnumerable<object> GetFavourites()
        {
            var favs = _edService.GetFavouritesByUserId(Security.CurrentUser.Id).ToList();
            var content = Services.ContentService.GetByIds(favs.Select(x => x.NodeId)).ToList();

            foreach (var fav in favs)
            {
                var node = content.FirstOrDefault(x => x.Id == fav.NodeId);
                if (node != null)
                {
                    yield return new {
                        id = fav.Id,
                        nodeId = node.Id,
                        name = node.Name
                    };
                }
            }
        }

        [HttpPost]
        public void RemoveFavourite(int id)
        {
            _edService.RemoveFavourite(id);
        }
    }
}
