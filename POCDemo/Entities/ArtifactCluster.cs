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

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class ArtifactCluster
    {
        public int LeafNodeCount { get; set; }
        public string Name { get; private set; }
        public int NodeCount { get; private set; }
        public int TotalDocumentCount { get; set; }
        public List<ArtifactClusterNode> Nodes { get; set; }
        public string NavigatorName { get; private set; }
        //public ClusterSort Sort { get; private set; }

        public ArtifactCluster()
        {
            Nodes = new List<ArtifactClusterNode>();
        }
    }
}
