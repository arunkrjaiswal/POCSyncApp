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
#endregion

#region Application Specific

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class NewReleasesDay
    {
        public NewReleaseCalendar NewReleasesCalendarItem { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public Int32 Day { get; set; }
        public DateTime Date { get; set; }
        public Boolean IsHoliday { get; set; }
        public Boolean IsDayOfThisMonth { get; set; }
        public Boolean IsNonWorkingDay { get; set; }

        public HyperLink ViewDetailsLink { get; set; }
    }
}
