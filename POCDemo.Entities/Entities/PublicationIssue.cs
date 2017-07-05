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

#endregion

#region Application Specific

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

#endregion

#endregion


namespace BT.TS360.BLL.Entities
{
    public class PublicationIssue : BaseList
    {
        #region Properties

        /// <summary>
        /// Publication ID
        /// </summary>
        /// <value>
        /// The publication identifier.
        /// </value>
        [BsonIgnoreIfNull]
        [BsonRepresentation(BsonType.ObjectId)]
        public String PublicationId
        {
            get; set;
        }

        /// <summary>
        /// Publication
        /// </summary>
        [BsonIgnoreIfNull]
        public String Publication
        {
            get; set;
        }

        /// <summary>
        /// IconImageUrl
        /// </summary>
        [BsonIgnoreIfNull]
        public String CoverImageUrl
        {
            get; set;
        }

        /// <summary>
        /// PdfFileUrl
        /// </summary>
        [BsonIgnoreIfNull]
        public String PdfFileUrl
        {
            get; set;
        }

        /// <summary>
        /// PublicationCategory
        /// </summary>
        [BsonIgnoreIfNull]
        [BsonIgnore]
        public List<PublicationCategory> PublicationCategories
        {
            get; set;
        }

        #endregion Properties
    }
}
