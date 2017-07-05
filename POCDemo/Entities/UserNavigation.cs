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
    public class UserNavigation
    {
        #region Properties
        /// <summary>
        /// Gets or sets the navigation identifier.
        /// </summary>
        /// <value>
        /// The navigation identifier.
        /// </value>
        public Int32 NavigationId
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the navigation code.
        /// </summary>
        /// <value>
        /// The navigation code.
        /// </value>
        public String NavigationCode
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the navigation text.
        /// </summary>
        /// <value>
        /// The navigation text.
        /// </value>
        public String NavigationText
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the additional HTML.
        /// </summary>
        /// <value>
        /// The additional HTML.
        /// </value>
        public String AdditionalHtml
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the site identifier.
        /// </summary>
        /// <value>
        /// The site identifier.
        /// </value>
        public Int32 SiteId
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the navigation parent identifier.
        /// </summary>
        /// <value>
        /// The navigation parent identifier.
        /// </value>
        public Int32? NavigationParentId
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the navigation parent code.
        /// </summary>
        /// <value>
        /// The navigation parent code.
        /// </value>
        public String NavigationParentCode
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the navigation parent text.
        /// </summary>
        /// <value>
        /// The navigation parent text.
        /// </value>
        public String NavigationParentText
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the navigation type identifier.
        /// </summary>
        /// <value>
        /// The navigation type identifier.
        /// </value>
        public Int32 NavigationTypeId
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the navigation type code.
        /// </summary>
        /// <value>
        /// The navigation type code.
        /// </value>
        public String NavigationTypeCode
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the type of the navigation.
        /// </summary>
        /// <value>
        /// The type of the navigation.
        /// </value>
        public String NavigationType
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the feature identifier.
        /// </summary>
        /// <value>
        /// The feature identifier.
        /// </value>
        public Int32? FeatureId
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the feature code.
        /// </summary>
        /// <value>
        /// The feature code.
        /// </value>
        public String FeatureCode
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the name of the feature.
        /// </summary>
        /// <value>
        /// The name of the feature.
        /// </value>
        public String FeatureName
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public String Link
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the content page identifier.
        /// </summary>
        /// <value>
        /// The content page identifier.
        /// </value>
        public Int32? ContentPageId
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the display order.
        /// </summary>
        /// <value>
        /// The display order.
        /// </value>
        public Int32? DisplayOrder
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is anomynous access.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is anomynous access; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsAnomynousAccess
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the child navigations.
        /// </summary>
        /// <value>
        /// The child navigations.
        /// </value>
        public List<UserNavigation> ChildNavigations
        {
            get; set;
        }

        #endregion Properties
    }
}
