namespace BT.TS360.BLL.Entities
{
    public class SiteLink : BaseList
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Target { get; set; }
        public string URL { get; set; }
        public string CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
