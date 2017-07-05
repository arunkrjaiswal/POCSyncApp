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
using System.Linq;

#endregion

#region Application Specific

using BT.TS360.Common.Utils;
using BT.TS360.Common.Utils.Enums;

#endregion

#endregion


namespace BT.TS360.BLL.Entities
{
    public class NewReleaseCalendar : BaseList
    {
        public DateTime ReleaseDate { get; set; }
        public String Description { get; set; }

        public String TopRelease { get; set; }
        public String ModifiedBy { get; set; }

        public List<ProductSearchResult> SearchedProducts { get; set; }

        public ContentManagementProductType ProductType { get; set; }

        public DateTime Date { get; set; }

        public String[] BTKeyList { get; set; }

        public Int32 NumberOfProducts => BTKeyList.IsNotNull() && BTKeyList.Any() ? BTKeyList.Length : 0;
    }
}
