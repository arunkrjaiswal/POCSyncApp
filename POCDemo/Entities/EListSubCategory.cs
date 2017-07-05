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
    public class EListSubCategory : BaseList
    {
        /// <summary>
        /// Gets or sets the e list category.
        /// </summary>
        /// <value>
        /// The e list category.
        /// </value>
        public String EListCategory { get; set; }

        /// <summary>
        /// Gets or sets the e list category identifier.
        /// </summary>
        /// <value>
        /// The e list category identifier.
        /// </value>
        [BsonRepresentation(BsonType.ObjectId)]
        public String EListCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the e lists.
        /// </summary>
        /// <value>
        /// The e lists.
        /// </value>
        public List<EList> ELists { get; set; }
    }
}
