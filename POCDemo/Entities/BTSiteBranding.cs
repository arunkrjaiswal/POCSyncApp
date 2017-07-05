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
    public class BTSiteBranding : BaseList
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the search string.
        /// </summary>
        /// <value>
        /// The search string.
        /// </value>
        public String SearchString
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the header image URL.
        /// </summary>
        /// <value>
        /// The header image URL.
        /// </value>
        public String HeaderImageUrl
        {

            get; set;
        }

        /// <summary>
        /// Gets or sets the footer image URL.
        /// </summary>
        /// <value>
        /// The footer image URL.
        /// </value>
        public String FooterImageUrl
        { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public String CreatedBy
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the created date time.
        /// </summary>
        /// <value>
        /// The created date time.
        /// </value>
        public String CreatedDateTime
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public String UpdatedBy
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the updated date time.
        /// </summary>
        /// <value>
        /// The updated date time.
        /// </value>
        public String UpdatedDateTime
        {
            get; set;
        }

        #endregion Properties
    }
}
