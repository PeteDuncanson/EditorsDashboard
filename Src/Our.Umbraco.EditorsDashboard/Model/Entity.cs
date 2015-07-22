using Newtonsoft.Json;

using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace Our.Umbraco.EditorsDashboard.Model
{
    [PrimaryKey("Id")]
    public class Entity
    {
        [JsonProperty("id")]
        [PrimaryKeyColumn]
        public int Id { get; set; }
    }
}
