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
#region System Namespaces

#endregion System Namespaces

#region Application Namespaces
using BT.TS360.BLL.Entities;
using BT.TS360.BLL.Helpers.Interface;
using BT.TS360.BLL.Helpers;
#endregion Application Namespaces

#endregion Namespaces

namespace BT.TS360.BLL
{
    /// <summary>
    /// CommonManager
    /// </summary>
    public class MongoDBContext<TEntity> where TEntity : BaseList
    {
        #region Private fields and constants

        private IMongoRepository<TEntity> _mongoRepositoryInstance;

        #endregion Private fields and constants

        #region Protected fields      

        #endregion Protected fields

        #region Public constants

        #endregion Public constants

        #region Public read-only static fields

        #endregion Public read-only static fields        

        #region Constructors and the Finalizer   


        #endregion Constructors and the Finalizer        

        #region Properties

        #region Public Properties

        public IMongoRepository<TEntity> MongoRepositoryInstance => _mongoRepositoryInstance ?? (_mongoRepositoryInstance = new MongoRepository<TEntity>());

        #endregion Public Properties

        #region Private Properties

        #endregion Private Properties

        #endregion Properties

        #region Methods

        #region Private Methods

        #endregion Private Methods

        #region Public Methods       

        #endregion Public Methods 

        #region Protected Methods

        #endregion Protected Methods

        #endregion Methods      
    }
}
