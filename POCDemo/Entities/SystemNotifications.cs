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
using BT.TS360.Common.Utils.Enums;
#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class SystemNotifications : BaseList
    {
        #region Variables
        private Priority0 _priorityEnum = Priority0.None;
        #endregion Variables

        #region Properties

        /// <summary>
        /// Gets or sets the notification text.
        /// </summary>
        /// <value>
        /// The notification text.
        /// </value>
        public String NotificationText { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>
        /// The priority.
        /// </value>
        private String Priority { get; set; }

        /// <summary>
        /// Gets or sets the priority enum.
        /// </summary>
        /// <value>
        /// The priority enum.
        /// </value>
        public Priority0 PriorityEnum
        {
            get
            {
                return _priorityEnum;
            }
            set
            {
                _priorityEnum = ToPriority0(Priority);
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// To the priority0.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private Priority0 ToPriority0(string value)
        {
            if (string.IsNullOrEmpty(value))
                return Priority0.None;
            switch (value)
            {
                case "High":
                    return Priority0.High;
                case "Medium":
                    return Priority0.Medium;
                case "Low":
                    return Priority0.Low;
                default:
                    return Priority0.Invalid;
            }
        }

        #endregion Methods
    }
}
