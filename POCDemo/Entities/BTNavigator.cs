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

using BT.TS360.Common.Utils.Enums;

#region Application Specific

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class BTNavigator
    {
        /// <summary>
        /// Gets or sets the bt navigator groups.
        /// </summary>
        /// <value>
        /// The bt navigator groups.
        /// </value>
        public List<BTNavigatorGroup> BTNavigatorGroups { get; set; }
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the document count.
        /// </summary>
        /// <value>
        /// The document count.
        /// </value>
        public int DocumentCount { get; set; }
        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>
        /// The name of the field.
        /// </value>
        public string FieldName { get; set; }
        /// <summary>
        /// Gets or sets the group count.
        /// </summary>
        /// <value>
        /// The group count.
        /// </value>
        public int GroupCount { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        public double Score { get; set; }
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public string Source { get; set; }
        /// <summary>
        /// Gets or sets the type of the field.
        /// </summary>
        /// <value>
        /// The type of the field.
        /// </value>
        public FieldType FieldType { get; set; }
        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>
        /// The unit.
        /// </value>
        public string Unit { get; set; }
        /// <summary>
        /// Gets or sets the display name of the summary.
        /// </summary>
        /// <value>
        /// The display name of the summary.
        /// </value>
        public string SummaryDisplayName { get; set; }
    }
}
