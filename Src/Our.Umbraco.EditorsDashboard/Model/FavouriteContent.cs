using Umbraco.Core.Persistence;

namespace Our.Umbraco.EditorsDashboard.Model
{
    [TableName("edFavouriteContent")]
    public class FavouriteContent : Entity
    {
        public int NodeId { get; set; }
        public int UserId { get; set; }
        public int SortOrder { get; set; }
    }
}
