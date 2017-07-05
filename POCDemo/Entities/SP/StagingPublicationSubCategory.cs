using BT.TS360.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCDemo.Entities.SP
{
    public class StagingPublicationSubCategory : BaseList
    {        
        public StringType ContentTypeId { get; set; }     
        public object _ModerationComments { get; set; }
        public object File_x0020_Type { get; set; }
        public EListLookup PublicationCategory { get; set; }
        public string BTKeyList { get; set; }     
        public double ReplicatedReferenceField { get; set; }
        public int ID { get; set; }
        public string Modified { get; set; }
        public string Created { get; set; }
        public EListLookup Author { get; set; }
        public EListLookup Editor { get; set; }
        public object _HasCopyDestinations { get; set; }
        public object _CopySource { get; set; }
        public int owshiddenversion { get; set; }
        public int WorkflowVersion { get; set; }
        public int _UIVersion { get; set; }
        public string _UIVersionString { get; set; }
        public bool Attachments { get; set; }
        public int _ModerationStatus { get; set; }
        public object InstanceID { get; set; }
        public double Order { get; set; }
        public string GUID { get; set; }
        public object WorkflowInstanceID { get; set; }
        public string FileRef { get; set; }
        public string FileDirRef { get; set; }
        public string Last_x0020_Modified { get; set; }
        public string Created_x0020_Date { get; set; }
        public string FSObjType { get; set; }
        public EListLookup SortBehavior { get; set; }
        public string FileLeafRef { get; set; }
        public string UniqueId { get; set; }
        public EListLookup SyncClientId { get; set; }
        public string ProgId { get; set; }
        public string ScopeId { get; set; }
        public string MetaInfo { get; set; }
        public int _Level { get; set; }
        public bool _IsCurrentVersion { get; set; }
        public string ItemChildCount { get; set; }
        public string FolderChildCount { get; set; }
    }
}
