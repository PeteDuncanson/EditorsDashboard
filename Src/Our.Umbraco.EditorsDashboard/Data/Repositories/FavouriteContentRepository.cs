using System.Collections;
using System.Collections.Generic;

using Our.Umbraco.EditorsDashboard.Extensions;
using Our.Umbraco.EditorsDashboard.Model;

namespace Our.Umbraco.EditorsDashboard.Data.Repositories
{
    internal class FavouriteContentRepository : AbstractRepository<FavouriteContent>
    {
        public virtual FavouriteContent Get(int nodeId, int userId)
        {
            return Db.SingleOrDefault<FavouriteContent>(string.Format("SELECT * FROM {0} WHERE [NodeId] = @0 AND [UserId] = @1",
                typeof(FavouriteContent).GetTableName()),
                nodeId,
                userId);
        }

        public virtual IEnumerable<FavouriteContent> GetByUserId(int userId)
        {
            return Db.Query<FavouriteContent>(string.Format("SELECT * FROM {0} WHERE [UserId] = @0 ORDER BY [SortOrder]",
                typeof(FavouriteContent).GetTableName()),
                userId);
        }
    }
}
