#region Header Comment Block

// Copyright  Baker & Taylor. 2017
// All rights are reserved.  Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of the copyright owner.
// 
// Filename:
// Purpose:   
//
// Revisions:
// Author           Date                Comment
// ------           ----------          -------------------------------------------------

#endregion

#region Namespaces

#region System Defined

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

#endregion

#region Application Specific

using BT.TS360.BLL.Entities;
using BT.TS360.BLL.Entities.Global;
using BT.TS360.BLL.Helpers.Interface;
using BT.TS360.Common.Helpers;
using BT.TS360.Common.Utils.Consts;
using BT.TS360.Common.Utils.Enums;
using MongoDB.Bson;
using MongoDB.Driver;

#endregion

#endregion

namespace BT.TS360.BLL.Helpers
{
    /// <summary>
    /// MongoRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : BaseList
    {
        private readonly IMongoDatabase _mongoDatabase;

        private readonly IMongoCollection<TEntity> _mongoCollection;

        private IMongoCollection<TEntity> MongoCollection => _mongoCollection;


        static MongoRepository()
        {
            MongoClassMapHelper.RegisterConventionPacks();
            MongoClassMapHelper.SetupClassMap();            
        }

        public MongoRepository()
        {
            var connectionString = GetConnectionString();
            var client = new MongoClient(connectionString);
            MongoUrl mongoUrl = MongoUrl.Create(connectionString);
            _mongoDatabase = client.GetDatabase(mongoUrl.DatabaseName);
            _mongoCollection = SetupCollection();
        }

        private String GetConnectionString()
        {
            // return "mongodb://admin:Password1@cluster0-shard-00-00-onwnr.mongodb.net:27017,cluster0-shard-00-01-onwnr.mongodb.net:27017,cluster0-shard-00-02-onwnr.mongodb.net:27017/TS360MongoDb?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin";
            return System.Configuration.ConfigurationManager
                .AppSettings
                .Get("MongoDbConnectionString")
                .Replace("{DB_NAME}", GetDatabaseName());
        }

        private String GetDatabaseName()
        {
            return ConfigurationManager
                .AppSettings
                .Get("MongoDBName");
        }

        private IMongoCollection<TEntity> SetupCollection()
        {
            try
            {
                //var collectionName = BuildCollectionName();
                var collection = _mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
                return collection;
            }
            catch (MongoException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //private String BuildCollectionName()
        //{
        //    var pluralizedName = typeof(TEntity).Name.EndsWith("s") ? typeof(TEntity).Name : typeof(TEntity).Name + "s";
        //    return pluralizedName;
        //}

        #region CRUD Functions

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception></exception>
        public TEntity Insert(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            //if (entity.Id == null)
            //{
            //    entity.Id = ObjectId.GenerateNewId();
            //}
            _mongoCollection.InsertOne(entity, cancellationToken: cancellationToken);

            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> InsertAll(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            //if (entity.Id == null)
            //{
            //    entity.Id = ObjectId.GenerateNewId();
            //}
            _mongoCollection.InsertMany(entity, cancellationToken: cancellationToken);

            return entity;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception>Document version conflicts. (Is out of date)</exception>
        public TEntity Update(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            entity.Version++;
            ReplaceOneResult result;
            var idFilter = Builders<TEntity>.Filter.Eq(e => e.Id, entity.Id); //Find entity with same Id

            //Consistency enforcement
            if (!IgnoreVersion())
            {
                var versionLowerThan = Builders<TEntity>.Filter.Lt(e => e.Version, entity.Version);

                result = MongoCollection.ReplaceOne(
                    // Consistency enforcement: Where current._id = entity.Id AND entity.Version > current.Version
                    Builders<TEntity>.Filter.And(idFilter, versionLowerThan), entity, null, cancellationToken);

                if (result != null && ((result.IsAcknowledged && result.MatchedCount == 0) || (result.IsModifiedCountAvailable && !(result.ModifiedCount > 0))))
                {
                    throw new Exception("Update failed because entity versions conflict!");
                }
            }
            else
            {
                result = MongoCollection.ReplaceOne(idFilter, entity, null, cancellationToken);

                if (result != null && ((result.IsAcknowledged && result.MatchedCount == 0) || (result.IsModifiedCountAvailable && !(result.ModifiedCount > 0))))
                {
                    throw new Exception("Entity does not exist.");
                }
            }

            return entity;
        }

        /// <summary>
        /// Gets entity by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public TEntity Get(String id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _mongoCollection.Find(e => e.Id == id).FirstOrDefault(cancellationToken);
        }

        /// <summary>
        /// Deletes entity by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public TEntity Delete(String id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _mongoCollection.FindOneAndDelete(e => e.Id == id, null, cancellationToken);
        }

        public DeleteResult DeleteAll(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _mongoCollection.DeleteMany(e => true);
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _mongoCollection.Find(e => true).ToList(cancellationToken);
        }

        public IEnumerable<TEntity> GetByName(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var collection = _mongoDatabase.GetCollection<TEntity>(name).Find(e => true).ToList(cancellationToken);
            return collection;
        }
        

        /// <summary>
        /// Paginations the entities.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> Pagination(Int32 top, Int32 skip, Func<TEntity, Object> orderBy, Boolean ascending = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = _mongoCollection.Find(e => true).Skip(skip).Limit(top);
            if (ascending)
                return query.SortBy(e => e.Id).ToList();
            else
                return query.SortByDescending(e => e.Id).ToList(cancellationToken);
        }

        /// <summary>
        /// GetCollectionByKey
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public List<TEntity> GetCollectionByKey(String field, object value, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _mongoCollection.Find(Builders<TEntity>.Filter.Eq(field, value)).ToList();
        }

        public List<TEntity> GetByValues(String field, IEnumerable<String> values, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _mongoCollection.Find(Builders<TEntity>.Filter.In(field, values)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ascending"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="filter"></param>
        /// <param name="limit"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<TEntity> GetCollectionByFilter(FilterDefinition<TEntity> filter, Int32? limit, Expression<Func<TEntity, Object>> orderBy, Boolean ascending, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = _mongoCollection.Find(filter).Limit(limit);

            if (ascending)
                return orderBy != null ? query.SortBy(orderBy).ToList() : query.ToList();
            else
                return orderBy != null ? query.SortByDescending(orderBy).ToList(cancellationToken) : query.ToList(cancellationToken);

        }

        /// <summary>
        /// GetCollectionByKeysElemMatch
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public List<TEntity> GetCollectionByKeysElemMatch(String key, String value, CancellationToken cancellationToken = default(CancellationToken))
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Regex(key, BsonRegularExpression.Create(new Regex(value, RegexOptions.IgnoreCase)));
            return _mongoCollection.Find(filter).ToList();
        }


        /// <summary>
        /// GetPaged
        /// </summary>
        /// <param name="queryParam"></param>
        /// <returns></returns>
        public List<TEntity> GetPaged(QueryParameter<TEntity> queryParam)
        {
            // TODO ::Share Point Dependency on HTTPContext  
            HttpContext httpContext = HttpContext.Current;
            List<TEntity> lists;
            FilterDefinition<TEntity> baseFilter;
            if (CommonHelper.IsMarketingUsers(httpContext))
            {
                baseFilter = CreateQuery(false, false, queryParam.HasAdName, queryParam.HasIsDefault);
                baseFilter = queryParam.PreviewConditionFilter == null ? baseFilter : baseFilter & (queryParam.PreviewConditionFilter);
                lists = GetPagedCollection(queryParam.Take, queryParam.Skip, baseFilter, queryParam.OrderBy, queryParam.Ascending);
                //Marketing Preview feature at authoring site.
                if (!lists.Any())
                {
                    baseFilter = CreateQuery(true, false, queryParam.HasAdName, queryParam.HasIsDefault);
                    baseFilter = queryParam.PreviewConditionFilter == null ? baseFilter : baseFilter & (queryParam.PreviewConditionFilter);
                    lists = GetPagedCollection(queryParam.Take, queryParam.Skip, baseFilter, queryParam.OrderBy, queryParam.Ascending);
                }
            }
            else
            {
                // Internet Site User  
                baseFilter = CreateQuery(false, true, queryParam.HasAdName, queryParam.HasIsDefault);
                baseFilter = queryParam.ConditionFilter == null ? baseFilter : baseFilter & (queryParam.ConditionFilter);
                lists = GetPagedCollection(queryParam.Take, queryParam.Skip, baseFilter, queryParam.OrderBy, queryParam.Ascending);
                if (!lists.Any())
                {
                    baseFilter = CreateQuery(true, true, queryParam.HasAdName, queryParam.HasIsDefault);
                    baseFilter = queryParam.ConditionFilter == null ? baseFilter : baseFilter & (queryParam.ConditionFilter);
                    lists = GetPagedCollection(queryParam.Take, queryParam.Skip, baseFilter, queryParam.OrderBy, queryParam.Ascending);
                }
            }
            return lists;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="queryParam"></param>
        /// <returns></returns>
        public List<TEntity> Get(QueryParameter<TEntity> queryParam)
        {
            // TODO ::Share Point Dependency on HTTPContext  
            HttpContext httpContext = HttpContext.Current;
            List<TEntity> lists;
            FilterDefinition<TEntity> baseFilter;
            if (CommonHelper.IsMarketingUsers(httpContext))
            {
                //Marketing Preview feature at authoring site.
                baseFilter = CreateQuery(false, false, queryParam.HasAdName, queryParam.HasIsDefault);
                baseFilter = queryParam.PreviewConditionFilter == null ? baseFilter : baseFilter & (queryParam.PreviewConditionFilter);
                lists = GetCollectionByFilter(baseFilter, queryParam.Limit, queryParam.OrderBy, queryParam.Ascending);
                if (!lists.Any())
                {
                    baseFilter = CreateQuery(true, false, queryParam.HasAdName);
                    baseFilter = queryParam.PreviewConditionFilter == null ? baseFilter : baseFilter & (queryParam.PreviewConditionFilter);
                    lists = GetCollectionByFilter(baseFilter, queryParam.Limit, queryParam.OrderBy, queryParam.Ascending);
                }
            }
            else
            {
                // Internet Site User  
                baseFilter = CreateQuery(false, true, queryParam.HasAdName);
                baseFilter = queryParam.ConditionFilter == null ? baseFilter : baseFilter & (queryParam.ConditionFilter);
                lists = GetCollectionByFilter(baseFilter, queryParam.Limit, queryParam.OrderBy, queryParam.Ascending);
                if (!lists.Any())
                {
                    baseFilter = CreateQuery(true, true, queryParam.HasAdName, queryParam.HasIsDefault);
                    baseFilter = queryParam.ConditionFilter == null ? baseFilter : baseFilter & (queryParam.ConditionFilter);
                    lists = GetCollectionByFilter(baseFilter, queryParam.Limit, queryParam.OrderBy, queryParam.Ascending);
                }
            }
            return lists;
        }

        /// <summary>
        /// GetPagedCollection
        /// </summary>
        /// <param name="top"></param>
        /// <param name="skip"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="ascending"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private List<TEntity> GetPagedCollection(int top, int skip, FilterDefinition<TEntity> filter, Expression<Func<TEntity, Object>> orderBy, bool ascending, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = _mongoCollection.Find(filter).Skip(skip).Limit(top);
            if (ascending)
                return orderBy != null ? query.SortBy(orderBy).ToList() : query.ToList();
            else
                return orderBy != null ? query.SortByDescending(orderBy).ToList(cancellationToken) : query.ToList(cancellationToken);

        }

        /// <summary>
        /// GetElists
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public List<TEntity> GetElists(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _mongoCollection.Find(e => true)
                .Project<TEntity>(Builders<TEntity>.Projection
                    .Include("EListSubcategories.Elists")
                    .Exclude("_id")).ToList();
        }

        #region async Methods

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception>Document version conflicts. (Is out of date)</exception>
        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            entity.Version++;

            ReplaceOneResult result;

            var idFilter = Builders<TEntity>.Filter.Eq(e => e.Id, entity.Id); //Find entity with same Id

            //Consistency enforcement
            if (!IgnoreVersion())
            {
                var versionLowerThan = Builders<TEntity>.Filter.Lt(e => e.Version, entity.Version);

                result = await MongoCollection.ReplaceOneAsync(
                    // Consistency enforcement: Where current._id = entity.Id AND entity.Version > current.Version
                    Builders<TEntity>.Filter.And(idFilter, versionLowerThan), entity, null, cancellationToken);

                if (result != null && ((result.IsAcknowledged && result.MatchedCount == 0) || (result.IsModifiedCountAvailable && !(result.ModifiedCount > 0))))
                {
                    throw new Exception("Update failed because entity versions conflict!");
                }
            }
            else
            {
                result = await MongoCollection.ReplaceOneAsync(idFilter, entity, null, cancellationToken);

                if (result != null && ((result.IsAcknowledged && result.MatchedCount == 0) || (result.IsModifiedCountAvailable && !(result.ModifiedCount > 0))))
                {
                    throw new Exception("Entity does not exist.");
                }
            }

            return entity;
        }

        /// <summary>
        /// Gets entity by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(String id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _mongoCollection.Find(e => e.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// Deletes entity by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<TEntity> DeleteAsync(String id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _mongoCollection.FindOneAndDeleteAsync(e => e.Id == id, null, cancellationToken);
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _mongoCollection.Find(e => true).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Paginations the entities.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> PaginationAsync(Int32 top, Int32 skip, Func<TEntity, Object> orderBy, Boolean ascending = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = _mongoCollection.Find(e => true).Skip(skip).Limit(top);

            if (ascending)
                return await query.SortBy(e => e.Id).ToListAsync(cancellationToken: cancellationToken);
            else
                return await query.SortByDescending(e => e.Id).ToListAsync(cancellationToken);
        }

        #endregion

        private static FilterDefinition<TEntity> CreateQuery(Boolean isDefault, Boolean isPublished, Boolean hasAdName, Boolean hasDefault = false)
        {
            FilterDefinition<TEntity> adFilter = GetAdNameExp(isDefault, hasAdName, hasDefault);

            FilterDefinition<TEntity> conditionFilter;
            //Query Condition
            if (isPublished)
            {
                conditionFilter = ((Builders<TEntity>.Filter.Eq(ApplicationConstants.EXPIRATION_DATE, (DateTime?)null)
                                    | Builders<TEntity>.Filter.Gt(ApplicationConstants.EXPIRATION_DATE, DateTime.Now))
                                   & Builders<TEntity>.Filter.Eq(ApplicationConstants.ITEM_STATUS, Enum.GetName(typeof(ItemStatus), ItemStatus.Published)));
            }
            else
            {
                conditionFilter = Builders<TEntity>.Filter.Eq(ApplicationConstants.ITEM_STATUS, Enum.GetName(typeof(ItemStatus), ItemStatus.Approved))
                                  | Builders<TEntity>.Filter.Eq(ApplicationConstants.ITEM_STATUS, Enum.GetName(typeof(ItemStatus), ItemStatus.Published));
            }
            var filter = adFilter == null ? conditionFilter : adFilter & conditionFilter;
            return filter;
        }

        private static FilterDefinition<TEntity> GetAdNameExp(Boolean isDefault, Boolean hasAdName, Boolean hasDefault)
        {
            FilterDefinition<TEntity> filter = null;
            if (!isDefault && hasAdName)
            {
                // Get Ad Name from CS MM :: Share Point Dependencies
                List<String> csList = new List<String>();// { "Ad000", "Ad001", "Ad002" };
                if (csList.Any())
                    filter = Builders<TEntity>.Filter.In(ApplicationConstants.AD_NAME, csList);
                else if (hasDefault)
                {
                    filter = Builders<TEntity>.Filter.Eq(ApplicationConstants.IS_DEFAULT, true);
                }
            }
            else if (hasDefault)
            {
                filter = Builders<TEntity>.Filter.Eq(ApplicationConstants.IS_DEFAULT, true);
            }
            return filter;
        }

        #endregion

        /// <summary>
        /// Ignores the document version.
        /// </summary>
        /// <returns></returns>
        private Boolean IgnoreVersion()
        {
            return true;
        }
    }
}
