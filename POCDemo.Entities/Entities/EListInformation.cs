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

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class EListInformation
    {
        /// <summary>
        /// FeaturedList
        /// </summary>
        /// <value>
        /// The featured list text.
        /// </value>
        public String FeaturedListText { get; set; }
        /// <summary>
        /// IsLibrarian
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is librarian; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsLibrarian { get; set; }
    }
}
