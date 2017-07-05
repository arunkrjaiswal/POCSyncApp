﻿#region Header Comment Block

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
    public class SiteConfiguration : BaseList
    {
        #region Properties

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public String Value
        {
            get; set;
        }

        #endregion Properties
    }
}
