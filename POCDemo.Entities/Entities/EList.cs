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
#endregion

#region Application Specific
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class EList : BaseList
    {
        #region Properties

        /// <summary>
        /// Gets or sets the e list sub category.
        /// </summary>
        /// <value>
        /// The e list sub category.
        /// </value>
        public String EListSubCategory { get; set; }

        /// <summary>
        /// Gets or sets the e list identifier.
        /// </summary>
        /// <value>
        /// The e list identifier.
        /// </value>
        [BsonRepresentation(BsonType.ObjectId)]
        public String EListId { get; set; }

        /// <summary>
        /// Gets or sets the e list category.
        /// </summary>
        /// <value>
        /// The e list category.
        /// </value>
        public String EListCategory { get; set; }

        /// <summary>
        /// Gets or sets the bt key list.
        /// </summary>
        /// <value>
        /// The bt key list.
        /// </value>
        public String[] BTKeyList { get; set; }

        /// <summary>
        /// Gets or sets the item currence URL.
        /// </summary>
        /// <value>
        /// The item currence URL.
        /// </value>
        public String ItemCurrenceURL { get; set; }

        #endregion Properties
    }
}
