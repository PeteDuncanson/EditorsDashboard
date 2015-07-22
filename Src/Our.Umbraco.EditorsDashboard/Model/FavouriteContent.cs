using Newtonsoft.Json;

using Umbraco.Core.Persistence;

namespace Our.Umbraco.EditorsDashboard.Model
{
    [TableName("edFavouriteContent")]
    public class FavouriteContent : Entity
    {
        [JsonProperty("nodeId")]
        public int NodeId { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("sortOrder")]
        public int SortOrder { get; set; }
    }
}
