using System;

namespace BT.TS360.BLL.Entities.Global
{
    public abstract class Address
    {
        public int Addressid { get; set; }
        public String OrganizationId { get; set; }
        public String City { get; set; }
        public String State { get; set; }

        public String Name { get; set; }
    }
}