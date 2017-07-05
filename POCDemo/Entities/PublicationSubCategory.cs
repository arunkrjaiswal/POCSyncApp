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
using BT.TS360.Common.Utils;

#endregion

#region Application Specific

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class PublicationSubCategory : BaseList
    {
        #region Variables

        private String _publicationSubCategoryId;

        #endregion Variables

        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [BsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        public override String Id
        {
            get; set;
        }

        /// <summary>
        /// Publication Category Id
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public String PublicationSubCategoryId
        {
            get
            {
                if (_publicationSubCategoryId.IsNull())
                {
                    _publicationSubCategoryId = ObjectId.GenerateNewId().ToString();

                }

                return _publicationSubCategoryId;
            }
            set
            {
                _publicationSubCategoryId = value;
            }
        }

        /// <summary>
        /// Publication Category
        /// </summary>
        public String PublicationCategory
        {
            get; set;
        }

        /// <summary>
        /// List of BTKeyList
        /// </summary>
        public String[] BTKeyList
        {
            get; set;
        }

        /// <summary>
        /// NavigateUrl
        /// </summary>
        public String NavigateUrl
        {
            get; set;
        }

        #endregion Properties
    }
}
