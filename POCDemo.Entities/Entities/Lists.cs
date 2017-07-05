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
    public class Lists : BaseList
    {
        /// <summary>
        /// Literal
        /// </summary>
        [BsonIgnoreIfNull]
        public String Literal { get; set; }

        /// <summary>
        /// ParentID
        /// </summary>
        [BsonIgnoreIfNull]
        public ObjectId ParentID { get; set; }

        /// <summary>
        /// AncestorIDs
        /// </summary>
        [BsonIgnoreIfNull]
        public List<ObjectId> AncestorIDs { get; set; }

        /// <summary>
        /// Sequence
        /// </summary>
        [BsonIgnoreIfNull]
        public Int32? Sequence { get; set; }

        /// <summary>
        /// ChildCount
        /// </summary>
        [BsonIgnoreIfNull]
        public Int32? ChildCount { get; set; }

        /// <summary>
        /// LeafIndicator
        /// </summary>
        [BsonIgnoreIfNull]
        public Boolean? LeafIndicator { get; set; }
    }
}
