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

using System;
using System.Collections.Generic;

#endregion

#region Application Specific

using BT.TS360.Common.Utils.Enums;

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class NewReleaseCalendarInfo
    {
        public DateTime? CurrentDate { get; set; }

        public String CurrentMonthStr => CurrentDate?.ToString("MMM") ?? String.Empty;
        public String ProductType { get; set; }
        public Int32 SelectedProdTypeIndex { get; set; }
        public int Month => CurrentDate?.Month ?? DateTime.Now.Month;
        public int Year => CurrentDate?.Year ?? DateTime.Now.Year;
        public NewReleasesCalendarStatus NewReleasesCalendarStatus { get; set; }
        public List<NewReleasesWeek> NewReleasesWeekCollection { get; set; }
        public List<NewReleasesDay> NewReleasesDayCollection { get; set; }

        public List<ProductSearchResult> ProductSearchResults { get; set; }
        public String CurrentDateText { get; set; }
        public Boolean IsPagePostBack { get; set; }
        public Boolean IsFiltering { get; set; }

        // Calendar Header Text
        public String SundayText { get; set; }
        public String MondayText { get; set; }
        public String TuesdayText { get; set; }
        public String WednesdayText { get; set; }
        public String ThursdayText { get; set; }
        public String FridayText { get; set; }
        public String SaturdayText { get; set; }
    }
}
