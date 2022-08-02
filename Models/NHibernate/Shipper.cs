using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;

namespace OrmPerformance.Models.NHibernate
{
    public class Shipper
    {
        public virtual int ShipperID { get; set; }
        public virtual string Phone { get; set; }
        public virtual IList<Order> Orders { get; set; }

    }

    public class ShipperMap : ClassMap<Shipper>
    {
        public ShipperMap()
        {
            Id(x => x.ShipperID);

            Map(x => x.Phone)
              .Nullable();

            HasMany(x => x.Orders).KeyColumn("ShipVia").Inverse().Cascade.All();

            Table("Shippers");
        }
    }
}
