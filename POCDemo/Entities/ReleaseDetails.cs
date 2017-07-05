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

namespace BT.TS360.BLL.Entities
{
    public class ReleaseDetails
    {
        #region Properties

        public string BrowseResultsPageUrl
        {
            get; set;
        }

        public HyperLink BooksType
        {
            get; set;
        }

        public HyperLink MoviesType
        {
            get; set;
        }

        public HyperLink MusicType
        {
            get; set;
        }

        public HyperLink AllTypes
        {
            get; set;
        }

        public string ViewAllMonth
        {
            get; set;
        }

        public int? ReleaseMonth
        {
            get; set;
        }

        public int? ReleaseYear
        {
            get; set;
        }

        public string ViewReleaseDetailsText
        {
            get; set;
        }

        #endregion Properties
    }
}
