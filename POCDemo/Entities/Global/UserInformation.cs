using BT.TS360.Common.Utils;
using BT.TS360.Common.Utils.Enums;
using System;
using System.Linq;

namespace BT.TS360.BLL.Entities.Global
{
    public class UserInformation
    {
        public SiteContext SiteContext
        {
            get; set;
        }
        public String OrganizationId
        {
            get; set;
        }
        public Boolean IsBTAdmin
        {
            get; set;
        }
        public Boolean MarketType
        {
            get; set;
        }
        public Boolean OriginalEntry
        {
            get; set;
        }
        public Boolean IsGridEnabled
        {
            get; set;
        }
        public Permissions Permissions
        {
            get; set;
        }
        public Boolean IsEnableStandingOrderServices
        {
            get; set;
        }
        public Boolean HasESPAcess()
        {
            return (Permissions.IsNotNull() && (Permissions.IsAllowed(PermissionType.ESPAccess)));
        }
        public Boolean CheckUserRole(string role)
        {
            var roleIds = role.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (Permissions.IsNull() || IsBTAdmin)
                return true;

            return roleIds.Select(roleId => (PermissionType)Enum.Parse(typeof(PermissionType), roleId)).Any(type => Permissions.IsAllowed(type));
        }
        public Address OrganizationAddress
        {
            get; set;
        }

        #region Header Information (NextGenLogo)        

        public String HomePageForLoggedInUser
        {
            get; set;
        }
        public String HomePageForAnonymousUser
        {
            get; set;
        }
        public String LogoForRetail
        {
            get; set;
        }
        public String MaintenanceURL
        {
            get; set;
        }
        public Boolean IsMaintenanceMode
        {
            get; set;
        }

        #endregion

        #region Used on Promotion page
        public String ProxiedUserId { get; set; }
        public String ReferedUrl { get; set; }

        #endregion
    }
}