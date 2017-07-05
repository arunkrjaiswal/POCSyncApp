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
    public class Promotion : BaseList
    {
        #region Properties

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public String ImageUrl
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the summary text.
        /// </summary>
        /// <value>
        /// The summary text.
        /// </value>
        public String SummaryText
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the detail text.
        /// </summary>
        /// <value>
        /// The detail text.
        /// </value>
        public String DetailText
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the promotion code.
        /// </summary>
        /// <value>
        /// The promotion code.
        /// </value>
        public String PromotionCode
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the image webtrends tag.
        /// </summary>
        /// <value>
        /// The image webtrends tag.
        /// </value>
        public String ImageWebtrendsTag
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the button webtrends tag.
        /// </summary>
        /// <value>
        /// The button webtrends tag.
        /// </value>
        public String ButtonWebtrendsTag
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the item currence URL.
        /// </summary>
        /// <value>
        /// The item currence URL.
        /// </value>
        public String ItemCurrenceURL
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the bt key list.
        /// </summary>
        /// <value>
        /// The bt key list.
        /// </value>
        public String BtKeyList
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the BTN post back URL.
        /// </summary>
        /// <value>
        /// The BTN post back URL.
        /// </value>
        public String BtnPostBackUrl
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the image redirect URL.
        /// </summary>
        /// <value>
        /// The image redirect URL.
        /// </value>
        public String ImageRedirectUrl
        {
            get; set;
        }


        #endregion Properties
    }
}
