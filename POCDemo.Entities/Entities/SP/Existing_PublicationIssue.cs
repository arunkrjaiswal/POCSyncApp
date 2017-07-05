namespace BT.TS360.BLL.Entities.SP
{
    public class Existing_PublicationIssue : BaseList
    {
        public string Publication { get; set; }

        public string PdfFileUrl { get; set; }
        public string CoverImageUrl { get; set; }
        public string CreatedBy { get; set; }
    }
}
