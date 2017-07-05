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
    public class TargetingParam
    {
        #region Properties

        /// <summary>
        /// Gets or sets the type of the audience.
        /// </summary>
        /// <value>
        /// The type of the audience.
        /// </value>
        public String AudienceType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the type of the market.
        /// </summary>
        /// <value>
        /// The type of the market.
        /// </value>
        public String MarketType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the org identifier.
        /// </summary>
        /// <value>
        /// The org identifier.
        /// </value>
        public String OrgId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the name of the org.
        /// </summary>
        /// <value>
        /// The name of the org.
        /// </value>
        public String OrgName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the pig.
        /// </summary>
        /// <value>
        /// The pig.
        /// </value>
        public String PIG
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the type of the product.
        /// </summary>
        /// <value>
        /// The type of the product.
        /// </value>
        public String ProductType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the site branding.
        /// </summary>
        /// <value>
        /// The site branding.
        /// </value>
        public String SiteBranding
        {
            get; set;
        }

        #endregion Properties
    }
}
