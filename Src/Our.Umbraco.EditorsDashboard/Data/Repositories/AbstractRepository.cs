using System;
using System.Collections.Generic;

using Our.Umbraco.EditorsDashboard.Extensions;
using Our.Umbraco.EditorsDashboard.Model;

using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Persistence;

namespace Our.Umbraco.EditorsDashboard.Data.Repositories
{
    internal abstract class AbstractRepository<TEntity>
        where TEntity : Entity, new()
    {
        protected Database Db
        {
            get { return ApplicationContext.Current.DatabaseContext.Database; }
        }

        public virtual TEntity Get(int id)
        {
            return Db.SingleOrDefault<TEntity>(id);
        }

        public virtual IEnumerable<TEntity> All()
        {
            return Db.Query<TEntity>(string.Format("SELECT * FROM {0}",
                typeof(TEntity).GetTableName()));
        }

        public virtual void Save(TEntity entity)
        {
            Db.Save(entity);
        }

        public virtual void Delete(int id)
        {
            Db.Delete(typeof(TEntity).GetTableName(),
                typeof(TEntity).GetPrimaryKeyName(),
                null,
                id);
        }

        public virtual void Delete(TEntity entity)
        {
            Db.Delete(entity);
        }

        public Transaction BegingTransaction()
        {
            return Db.GetTransaction();
        }

        public bool EnsureDatabaseTable()
        {
            try
            {
                if (!Db.TableExist(typeof(TEntity).GetTableName()))
                {
                    Db.CreateTable<TEntity>(false);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error<AbstractRepository<TEntity>>("Error ensuring database table", ex);
                return false;
            }
        }
    }
}
