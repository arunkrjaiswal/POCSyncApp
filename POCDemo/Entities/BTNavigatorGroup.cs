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

using BT.TS360.Common.Utils.Enums;

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class BTNavigatorGroup
    {
        public string DisplayName { get; set; }
        public int DocumentCount { get; set; }
        public double DocumentRatio { get; set; }
        public string Value { get; set; }

        public string DataValueField { get; set; }
        public string DataParentValueField { get; set; }
        public int DataLevelField { get; set; }

        public string FieldName { get; set; }
        public string NavigatorDisplayName { get; set; }
        public FieldType NavigatorType { get; set; }
        public string Url { get; set; }
    }
}
