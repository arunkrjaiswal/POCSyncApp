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

#endregion

#region Application Specific

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class TitleBar : BaseList
    {
        #region Properties

        /// <summary>
        /// Gets or sets the site logo.
        /// </summary>
        /// <value>
        /// The site logo.
        /// </value>
        public string SiteLogo { get; set; }

        /// <summary>
        /// Gets or sets the site title.
        /// </summary>
        /// <value>
        /// The site title.
        /// </value>
        public string SiteTitle { get; set; }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        /// <value>
        /// The background image.
        /// </value>
        public string BackgroundImage { get; set; }

        #endregion Properties
    }
}
