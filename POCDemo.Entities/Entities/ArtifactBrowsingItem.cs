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

namespace BT.TS360.BLL.Entities
{
    public class ArtifactBrowsingItem
    {
        public string ArtifactCategoryID { get; set; }
        public string ArtifactCategoryUCID { get; set; }
        public string ArtifactCategoryName { get; set; }
        public string ArtifactTypeID { get; set; }
        public string ArtifactTypeUCID { get; set; }
        public string ArtifactTypeName { get; set; }
        public int ArtifactProductCount { get; set; }
        public string ArtifactWorkUCID { get; set; }
    }
}
