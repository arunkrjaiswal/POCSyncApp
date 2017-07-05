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

#endregion

#region Application Specific

using BT.TS360.Common.Utils.Enums;

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class ProductSearchResult : BaseList
    {
        #region Properties

        public string BTKey
        {
            get; set;
        }

        public ContentManagementProductType ProductType
        {
            get; set;
        }

        public string Author
        {
            get; set;
        }

        public string FormatIconPath
        {
            get
            {
                if (ProductType.Equals(ContentManagementProductType.Books))
                {
                    return "/content/images/icons/icon_format_book.jpg";
                }
                else if (ProductType.Equals(ContentManagementProductType.EntertainmentMovies))
                {
                    return "/content/images/icons/icon_format_dvd.png";
                }
                else
                {
                    return "/content/images/icons/icon_format_cd.png";
                }
            }
        }

        public HyperLink ReleaseTitleLink => new HyperLink
        {
            NavigateUrl = "#",
            Text = Title
        };

        #endregion Properties
    }
}
