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
using System.Linq;
#endregion

#region Application Specific

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class ArtifactClusterNode
    {
        public ArtifactClusterNode()
        {
            SubNodes = new List<ArtifactClusterNode>();
        }
        public string ClusterName { get; set; }
        public int LocalDocumentCount { get; internal set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int SubNodeCount { get; set; }
        public List<ArtifactClusterNode> SubNodes { get; }
        public int TotalDocumentCount { get; private set; }

        /// <summary>
        /// TFS 2000 for Publish Date facet.
        /// </summary>
        /// <param name="count"></param>
        public void SetTotalDocumentCount(int count)
        {
            TotalDocumentCount = count;
        }
        internal string PathName { get; set; }
        internal string SortKey { get; set; }

        public static int CalculateLeafNodeCount(ArtifactClusterNode node)
        {
            return node.SubNodes.Count == 0 ? 1 : node.SubNodes.Sum(CalculateLeafNodeCount);
        }
    }
}
