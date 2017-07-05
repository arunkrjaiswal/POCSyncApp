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
    public class LibrariansCorner : BaseList
    {
        public String ListCategory { get; set; }

        public String ListSubCategory { get; set; }

        public String ListName { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public String EListId { get; set; }

        public String BTKeySearch { get; set; }
    }
}
