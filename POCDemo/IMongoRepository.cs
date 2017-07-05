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
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

#endregion

#region Application Specific
using BT.TS360.BLL.Entities;
using BT.TS360.BLL.Entities.Global;

#endregion

#endregion

namespace BT.TS360.BLL.Helpers.Interface
{
    public interface IMongoRepository<TEntity> where TEntity : BaseList
    {
        #region Mongo Method

        #region Method
        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        TEntity Insert(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Inserts multiple entities.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        IEnumerable<TEntity> InsertAll(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        TEntity Update(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets entity by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        TEntity Get(String id, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        TEntity Delete(String id, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        DeleteResult DeleteAll(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Paginations the entities.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        IEnumerable<TEntity> Pagination(Int32 top, Int32 skip, Func<TEntity, Object> orderBy, Boolean ascending = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(CancellationToken cancellationToken = default(CancellationToken));

        IEnumerable<TEntity> GetByName(string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// GetCollectionByKey
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        List<TEntity> GetCollectionByKey(String field, object value, CancellationToken cancellationToken = default(CancellationToken));

        List<TEntity> GetByValues(String field, IEnumerable<String> values, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// GetCollectionByKeysElemMatch
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        List<TEntity> GetCollectionByKeysElemMatch(String key, String value, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        List<TEntity> GetElists(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// GetCollectionByFilter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="ascending"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="limit"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        List<TEntity> GetCollectionByFilter(FilterDefinition<TEntity> filter, Int32? limit, Expression<Func<TEntity, Object>> orderBy, Boolean ascending, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="queryParam"></param>
        /// <returns></returns>
        List<TEntity> Get(QueryParameter<TEntity> queryParam);

        /// <summary>
        /// GetPaged
        /// </summary>
        /// <param name="queryParam"></param>
        /// <returns></returns>
        List<TEntity> GetPaged(QueryParameter<TEntity> queryParam);

        #endregion

        #region Asynch Method         

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets entity by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(String id, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TEntity> DeleteAsync(String id, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Paginations the entities.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> PaginationAsync(Int32 top, Int32 skip, Func<TEntity, Object> orderBy, Boolean ascending = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        #endregion

        #region Module Method

        #endregion

        #endregion
    }
}
