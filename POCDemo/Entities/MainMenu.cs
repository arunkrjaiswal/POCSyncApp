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

using System.Collections.Generic;

#endregion

#region Application Specific

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class MainMenu
    {
        /// <summary>
        /// Gets or sets the authenticated menu items.
        /// </summary>
        /// <value>
        /// The authenticated menu items.
        /// </value>
        public List<MenuItem> AuthenticatedMenuItems
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the anonymous menu items.
        /// </summary>
        /// <value>
        /// The anonymous menu items.
        /// </value>
        public List<MenuItem> AnonymousMenuItems
        {
            get; set;
        }
    }
}
