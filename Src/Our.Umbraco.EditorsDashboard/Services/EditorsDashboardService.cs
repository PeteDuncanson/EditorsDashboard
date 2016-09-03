using System;
using System.Collections.Generic;
using System.Linq;
using Our.Umbraco.EditorsDashboard.Data.Repositories;
using Our.Umbraco.EditorsDashboard.Model;
using Umbraco.Core;
using Umbraco.Core.Services;

namespace Our.Umbraco.EditorsDashboard.Services
{
    internal class EditorsDashboardService
    {
        private FavouriteContentRepository _fcRepo;

        private CacheHelper Cache
        {
            get
            {
                return ApplicationContext.Current.ApplicationCache;
            }
        }

        private ServiceContext Services
        {
            get
            {
                return ApplicationContext.Current.Services;
            }
        }

        public EditorsDashboardService()
        {
            _fcRepo = new FavouriteContentRepository();
        }

        public FavouriteContent AddToFavourites(int nodeId, int userId)
        {
            var existing = this.GetFavourite(nodeId, userId);
            if (existing != null)
            {
                return existing;
            }

            var fc = new FavouriteContent
            {
                NodeId = nodeId,
                UserId = userId,
                SortOrder = 0
            };

            if (FavouriteContentValid(fc))
            {
                _fcRepo.Save(fc);

                // Clear the cache
                ClearCache(userId);

                return fc;
            }

            return null;
        }

        public FavouriteContent GetFavourite(int nodeId, int userId)
        {
            var existing = _fcRepo.Get(nodeId, userId);
            if (existing != null)
            {
                if (!FavouriteContentValid(existing))
                {
                    _fcRepo.Delete(existing);

                    return null;
                }

                return existing;
            }

            return null;
        }

        public bool HasFavourite(int nodeId, int userId)
        {
            var favourites = GetFavouritesByUserId(userId, true);
            return favourites.Any(x => x.NodeId == nodeId);
        }

        public IEnumerable<FavouriteContent> GetFavouritesByUserId(int userId)
        {
            return _fcRepo.GetByUserId(userId);
        }

        public IEnumerable<FavouriteContent> GetFavouritesByUserId(int userId, bool cache)
        {
            if (!cache)
            {
                return GetFavouritesByUserId(userId);
            }

            var cacheKey = string.Concat("EditorsDashboardService_GetFavouritesByUserId_", userId);
            Func<object> func = () => { return GetFavouritesByUserId(userId); };

            return (IEnumerable<FavouriteContent>)Cache.RuntimeCache.GetCacheItem(cacheKey, func);
        }

        public void RemoveFromFavourites(int nodeId, int userId)
        {
            var favourite = this.GetFavourite(nodeId, userId);

            if (favourite != null)
            {
                _fcRepo.Delete(favourite);

                // Clear the cache
                ClearCache(userId);
            }
        }

        private void ClearCache(int userId)
        {
            var cacheKey = string.Concat("EditorsDashboardService_GetFavouritesByUserId_", userId);
            Cache.RuntimeCache.ClearCacheItem(cacheKey);
        }

        private bool FavouriteContentValid(FavouriteContent fc)
        {
            var node = Services.ContentService.GetById(fc.NodeId);

            // Check node exists
            if (node == null)
            {
                return false;
            }

            // Check not in the bin
            if (node.ParentId == Constants.System.RecycleBinContent)
            {
                return false;
            }

            // Check user exists
            return Services.UserService.GetUserById(fc.UserId) != null;
        }
    }
}