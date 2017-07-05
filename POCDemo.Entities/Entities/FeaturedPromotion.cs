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
    public class FeaturedPromotion : BaseList
    {
        /// <summary>
        /// Gets or sets the featured promo image.
        /// </summary>
        /// <value>
        /// The featured promo image.
        /// </value>
        public String FeaturedPromoImage
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the featured promo text.
        /// </summary>
        /// <value>
        /// The featured promo text.
        /// </value>
        public String FeaturedPromoText
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the featured promo background.
        /// </summary>
        /// <value>
        /// The featured promo background.
        /// </value>
        public String FeaturedPromoBackground
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the featured promotion URL.
        /// </summary>
        /// <value>
        /// The featured promotion URL.
        /// </value>
        public String FeaturedPromotionURL
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the bt keys.
        /// </summary>
        /// <value>
        /// The bt keys.
        /// </value>
        public String[] BTKeys
        {
            get; set;
        }
    }
}
