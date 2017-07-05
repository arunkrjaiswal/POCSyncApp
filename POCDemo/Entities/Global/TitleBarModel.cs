using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BT.TS360.BLL.Entities.Global
{
    public class TitleBarModel
    {
        public String SiteLogo { get; set; }

        public String SiteTitle { get; set; }

        public String BackgroundImage { get; set; }

        public String SiteAlt { get; set; }
        public String SiteLink { get; set; }

        public BTSiteBrandingModel BTSiteBranding { get; set; }
    }

    public class BTSiteBrandingModel
    {
        public Int32 SiteBrandingId { get; set; }
        public String SiteBrandingName { get; set; }
        public String SearchString { get; set; }
        public Boolean IsDefault { get; set; }
        public String HeaderImageUrl { get; set; }
        public String FooterImageUrl { get; set; }
    }
}