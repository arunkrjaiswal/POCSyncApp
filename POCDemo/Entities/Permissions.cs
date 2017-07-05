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

#region Application Specific

using BT.TS360.Common.Utils;
using BT.TS360.Common.Utils.Enums;

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class Permissions
    {
        #region Properties

        /// <summary>
        /// Gets or sets the allowed permissions.
        /// </summary>
        /// <value>
        /// The allowed permissions.
        /// </value>
        private List<PermissionType> AllowedPermissions
        {
            get;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="Permissions"/> class.
        /// </summary>
        protected Permissions()
        {
            if (AllowedPermissions.IsNull())
            {
                AllowedPermissions = new List<PermissionType>();
            }
        }

        /// <summary>
        /// Adds the permission.
        /// </summary>
        /// <param name="permissionType">Type of the permission.</param>
        public void AddPermission(PermissionType permissionType)
        {
            AllowedPermissions.Add(permissionType);
        }

        /// <summary>
        /// Determines whether the specified permission is allowed.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns>
        ///   <c>true</c> if the specified permission is allowed; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAllowed(PermissionType permission)
        {
            return AllowedPermissions.Contains(permission);
        }

        #endregion Methods
    }
}
