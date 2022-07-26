using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;

namespace OrmPerformance.Models.NHibernate
{
    public class Shipper
    {
        public virtual string Phone { get; set; }
    }

    public class ShipperMap : ClassMap<Shipper>
    {
        public ShipperMap()
        {

            Map(x => x.Phone)
              .Nullable();

            //Property(b => b.Phone, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            Table("Shippers");
        }
    }
}
