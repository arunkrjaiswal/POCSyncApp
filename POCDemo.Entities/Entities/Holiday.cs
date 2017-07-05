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
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BT.TS360.BLL.Entities.BaseList" />
    public class Holidays : BaseList
    {
        /// <summary>
        /// Gets or sets the holiday.
        /// </summary>
        /// <value>
        /// The holiday.
        /// </value>
        public String Holiday
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime? Date
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the holiday text.
        /// </summary>
        /// <value>
        /// The holiday text.
        /// </value>
        public String HolidayText
        {
            get; set;
        }
    }
}
