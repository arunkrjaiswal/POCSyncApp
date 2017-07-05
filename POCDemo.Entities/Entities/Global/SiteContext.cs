using BT.TS360.Common.Utils.Enums;

namespace BT.TS360.BLL.Entities.Global
{
    public class SiteContext
    {
        public string UserId
        {
            get; set;
        }
        public string LoginId
        {
            get;
            set;
        }
        public string CountryCode
        {
            get;
            set;
        }
        public MarketType? MarketType
        {
            get;
            set;
        }
        public string[] ESuppliers
        {
            get; set;
        }
        public bool SimonSchusterEnabled
        {
            get; set;
        }
        public bool CollectionAnalysisEnabled
        {
            get; set;
        }
    }
}