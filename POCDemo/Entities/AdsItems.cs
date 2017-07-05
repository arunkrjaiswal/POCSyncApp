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
    public class AdsItem : BaseList
    {
        /// <summary>
        /// Gets or sets the model name definition.
        /// </summary>
        /// <value>
        /// The model name definition.
        /// </value>
        public String ModelNameDefinition { get; set; }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public String Context { get; set; }

        /// <summary>
        /// Gets or sets the name of the context.
        /// </summary>
        /// <value>
        /// The name of the context.
        /// </value>
        public String ContextName { get; set; }
    }
}
