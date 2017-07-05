namespace BT.TS360.BLL.Entities.SP
{
    public class Existing_Publication : BaseList
    {
        public string ContentType { get; set; }
        public string IconImageUrl { get; set; }
        public string Description { get; set; }
        public string Created { get; set; }
        public string CreatedBy { get; set; }
        public int FolderChildCount { get; set; }
        public int ItemChildCount { get; set; }
        public string Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
