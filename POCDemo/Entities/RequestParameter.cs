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

    public class RequestContextParameter
    {
        #region Properties

        public Int32 PageNumber { get; set; }
        public Int32 PageSize { get; set; }
        public String OrderByColumn { get; set; }
        public String OrderByDirection { get; set; }
        public String KeywordSearch { get; set; }

        #endregion Properties
    }

    public class ResponseContextParameter
    {
        #region Properties
        public Int32 NumberOfRecords { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// UserContext
    /// </summary>
    public class UserContext
    {
        #region Properties

        /// <summary>
        /// UserId
        /// </summary>
        public Int32 UserId { get; set; }

        /// <summary>
        /// LanguageId
        /// </summary>
        public Int32 LanguageId { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        public String Language { get; set; }

        /// <summary>
        /// SiteId
        /// </summary>
        public Int32 SiteId { get; set; }

        /// <summary>
        /// ImpersonateViewRights
        /// </summary>
        public Boolean ImpersonateViewRights { get; set; }


        #endregion 
    }
}
