using BT.TS360.Common.Utils.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.TS360.BLL.Entities
{
    public class SearchSection
    {
        public String InitialText
        {
            get; set;
        }
        public HyperLink AdvancedSearch
        {
            get; set;
        }
        public HyperLink SavedSearches
        {
            get; set;
        }

        public String SuggestionItemsLimit
        {
            get
            {
                return ApplicationConstants.Suggestion_Items_Limit_Default;
            }
        }

        public String SuggestionDelayTime
        {
            get
            {
                return ApplicationConstants.Suggestion_Delay_Time_Default;
            }
        }

        public HyperLink QuickSearch { get; set; }

        public HyperLink SearchResults { get; set; }
    }
}
