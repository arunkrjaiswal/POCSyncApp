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
    /// <summary>
    /// FeaturedBTeLists
    /// </summary>
    public class FeaturedBTeList : BaseList
    {
        /// <summary>
        /// Gets or sets the list category.
        /// </summary>
        /// <value>
        /// The list category.
        /// </value>
        public String ListCategory { get; set; }

        /// <summary>
        /// Gets or sets the list sub category.
        /// </summary>
        /// <value>
        /// The list sub category.
        /// </value>
        public String ListSubCategory { get; set; }

        /// <summary>
        /// Gets or sets the name of the list.
        /// </summary>
        /// <value>
        /// The name of the list.
        /// </value>
        public String ListName { get; set; }

        /// <summary>
        /// Gets or sets the e list identifier.
        /// </summary>
        /// <value>
        /// The e list identifier.
        /// </value>
        [BsonRepresentation(BsonType.ObjectId)]
        public String EListId { get; set; }

        /// <summary>
        /// Gets or sets the bt key search.
        /// </summary>
        /// <value>
        /// The bt key search.
        /// </value>
        public String BTKeySearch { get; set; }

        /// <summary>
        /// Gets the name of the ad.
        /// </summary>
        /// <returns></returns>
        public String GetAdName()
        {
            return String.Empty;
        }
    }
}
