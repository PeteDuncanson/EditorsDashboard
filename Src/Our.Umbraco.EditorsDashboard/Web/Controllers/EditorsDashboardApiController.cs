using System.Web.Http;
using Umbraco.Core.Models;
using Umbraco.Web.WebApi;

namespace Our.Umbraco.EditorsDashboard.Web.Controllers
{
    public class EditorsDashboardApiController : UmbracoAuthorizedApiController
    {
        [HttpGet]
        public PagedResult<object> GetUsers()
        {
            return null;
        }
    }
}
