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
    public class PublicationCategory : BaseList
    {
        #region Properties

        /// <summary>
        /// PublicationIssueId
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public String PublicationIssueId
        {
            get; set;
        }

        /// <summary>
        /// PublicationIssue
        /// </summary>
        public String PublicationIssue
        {
            get; set;
        }

        /// <summary>
        /// List of Publication Sub Categories
        /// </summary>
        /// <value>
        /// The publication sub categories.
        /// </value>
        [BsonIgnoreIfNull]
        public List<PublicationSubCategory> PublicationSubCategories
        {
            get; set;
        }

        /// <summary>
        /// IsShowMore
        /// </summary>
        public Boolean IsShowMore
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
