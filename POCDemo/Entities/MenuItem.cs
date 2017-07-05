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

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class MenuItem
    {
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public string Role
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the sub menus.
        /// </summary>
        /// <value>
        /// The sub menus.
        /// </value>
        public List<MenuItem> SubMenus
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the display text.
        /// </summary>
        /// <value>
        /// The display text.
        /// </value>
        public string DisplayText
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is parent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is parent; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsParent
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsSelected
        {
            get; set;
        }

        public Boolean IsAppendBaseURL
        {
            get; set;
        }
    }
}
