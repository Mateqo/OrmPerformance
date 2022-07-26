using FluentNHibernate.Mapping;

namespace OrmPerformance.Models.NHibernate
{
    public class Order
    {
        public virtual int OrderID { get; set; }
        //public virtual string CustomerID { get; set; }
        //public virtual int EmployeeID { get; set; }
        //public virtual int ShipVia { get; set; }
        public virtual string ShipName { get; set; }
        public virtual string ShipAddress { get; set; }
        public virtual string ShipCity { get; set; }
        public virtual string ShipRegion { get; set; }
        public virtual string ShipPostalCode { get; set; }
        public virtual string ShipCountry { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Shipper Shipper { get; set; }
    }

    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.OrderID);

            Map(x => x.ShipName)
                .Nullable();

            Map(x => x.ShipAddress)
              .Nullable();

            Map(x => x.ShipCity)
               .Nullable();

            Map(x => x.ShipRegion)
              .Nullable();

            Map(x => x.ShipPostalCode)
              .Nullable();

            Map(x => x.ShipCountry)
             .Nullable();

            References(x => x.Customer);
            References(x => x.Employee);
            References(x => x.Shipper);

            //Id(x => x.OrderID, x =>
            //{
            //    x.Generator(Generators.Assigned);
            //    x.Type(NHibernateUtil.Int32);
            //    x.Column("OrderID");
            //});

            //Property(b => b.ShipName, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.ShipAddress, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.ShipCity, x =>
            //{
            //    x.Length(60);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.ShipRegion, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.ShipPostalCode, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.ShipCountry, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //OneToOne(x => x.CustomerID, m =>
            //{
            //    m.Cascade(Cascade.Persist);
            //    m.Constrained(true);
            //    m.Lazy(LazyRelation.Proxy);
            //    m.PropertyReference(typeof(Customer).GetPropertyOrFieldMatchingName("CustomerID"));
            //    m.OptimisticLock(true);
            //    m.Formula("arbitrary SQL expression");
            //    m.Access(Accessor.Field);
            //});

            //OneToOne(x => x.EmployeeID, m =>
            //{
            //    m.Cascade(Cascade.Persist);
            //    m.Constrained(true);
            //    m.Lazy(LazyRelation.Proxy);
            //    m.PropertyReference(typeof(Employee).GetPropertyOrFieldMatchingName("EmployeeID"));
            //    m.OptimisticLock(true);
            //    m.Formula("arbitrary SQL expression");
            //    m.Access(Accessor.Field);
            //});

            Table("Orders");
        }
    }
}
