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
    public class NewReleasesWeek
    {
        public NewReleasesDay Sunday { get; set; }
        public NewReleasesDay Monday { get; set; }
        public NewReleasesDay Tuesday { get; set; }
        public NewReleasesDay Wednesday { get; set; }
        public NewReleasesDay Thursday { get; set; }
        public NewReleasesDay Friday { get; set; }
        public NewReleasesDay Saturday { get; set; }

        public void SetDayOfWeek(NewReleasesDay newReleasesDay)
        {
            switch (newReleasesDay.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    Sunday = newReleasesDay;
                    break;
                case DayOfWeek.Monday:
                    Monday = newReleasesDay;
                    break;
                case DayOfWeek.Tuesday:
                    Tuesday = newReleasesDay;
                    break;
                case DayOfWeek.Wednesday:
                    Wednesday = newReleasesDay;
                    break;
                case DayOfWeek.Thursday:
                    Thursday = newReleasesDay;
                    break;
                case DayOfWeek.Friday:
                    Friday = newReleasesDay;
                    break;
                case DayOfWeek.Saturday:
                    Saturday = newReleasesDay;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
