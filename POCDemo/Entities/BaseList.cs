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
using System.Collections.Generic;
using System;

#endregion

#region Application Specific

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    [Serializable]
    public class BaseList
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [BsonElement("_id")]
        [BsonIgnoreIfNull]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual String Id
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the sp list identifier.
        /// </summary>
        /// <value>
        /// The sp list identifier.
        /// </value>
        [BsonIgnoreIfNull]
        public Int32 SPListId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [BsonIgnoreIfNull]
        public String Title
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the name of the ad.
        /// </summary>
        /// <value>
        /// The name of the ad.
        /// </value>
        [BsonIgnoreIfNull]
        public String AdName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the is default.
        /// </summary>
        /// <value>
        /// The is default.
        /// </value>
        [BsonIgnoreIfNull]
        public Boolean IsDefault
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the item status.
        /// </summary>
        /// <value>
        /// The item status.
        /// </value>
        [BsonIgnoreIfNull]
        public String ItemStatus
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the published date.
        /// </summary>
        /// <value>
        /// The published date.
        /// </value>
        [BsonIgnoreIfNull]
        public DateTime? PublishedDate
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        [BsonIgnoreIfNull]
        public DateTime? ExpirationDate
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the content owner.
        /// </summary>
        /// <value>
        /// The content owner.
        /// </value>
        [BsonIgnoreIfNull]
        public String ContentOwner
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the approver.
        /// </summary>
        /// <value>
        /// The approver.
        /// </value>
        [BsonIgnoreIfNull]
        public String Approver
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the approved date.
        /// </summary>
        /// <value>
        /// The approved date.
        /// </value>
        [BsonIgnoreIfNull]
        public DateTime? ApprovedDate
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        [BsonIgnoreIfNull]
        public String Comment
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>
        /// The type of the item.
        /// </value>
        [BsonIgnoreIfNull]
        public String ItemType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        [BsonIgnoreIfNull]
        public String Path
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [BsonIgnoreIfNull]
        public Int64 Version
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        /// <value>
        /// The metadata.
        /// </value>
        [BsonIgnoreIfNull]
        public IDictionary<String, Object> Metadata
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        [BsonIgnoreIfNull]
        public DateTime? StartDate
        {
            get; set;
        }

        /// <summary>
        /// DisplayOrder
        /// </summary>
        public String DisplayOrder
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        protected BaseList()
        {
            Metadata = new Dictionary<String, Object>();
        }
    }
}